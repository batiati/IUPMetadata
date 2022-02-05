using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace IupMetadata
{
	public static class MetadataExtractor
	{
		#region Fields

		private const int BUFFER_SIZE = 4096;

		#endregion Fields

		#region Constructor

		static MetadataExtractor()
		{
			Debug.Assert(Interop.IupOpen(IntPtr.Zero, IntPtr.Zero) == 0);
			Debug.Assert(Interop.IupControlsOpen() == 0);
		}

		#endregion Constructor

		#region Methods

		#region Documentation

		/// <summary>
		/// Extracts all classes, attributes and callbacks registered in IUP
		/// </summary>

		#endregion Documentation

		public static IupClass[] GetClasses(string docsPath)
		{
			var result = new List<IupClass>();

			var classnames = new IntPtr[BUFFER_SIZE];
			var ret = Interop.IupGetAllClasses(classnames, BUFFER_SIZE);

			for (int i = 0; i < ret; i++)
			{
				var classname = classnames[i];
				var iupClass = Marshal.PtrToStructure<Interop.IClass>(Interop.iupRegisterFindClass(classname));

				var item = new IupClass();

				item.ClassName = iupClass.name;
				item.Name = UpperCaseConverter.ToTitleCase(iupClass.name);

				#region Comments

				// IUP childtype means 0=None, 1=Many, Many+N = N Children
				// Translating to simpler 0=None, -1=Many, Other value = quantity

				#endregion Comments

				item.ChildrenCount = iupClass.childtype switch
				{
					0 => 0,
					1 => -1,
					_ => iupClass.childtype - 1
				};

				if (iupClass.parent != IntPtr.Zero)
				{
					var parentIclass = Marshal.PtrToStructure<Interop.IClass>(iupClass.parent);
					item.ParentClassName = parentIclass.name;
				}

				item.NativeType = (NativeType)iupClass.nativetype;
				item.NumberedAttributes = (NumberedAttribute)iupClass.has_attrib_id;
				item.IsInteractive = iupClass.is_interactive == 1;
				item.Attributes = GetAttributes(classname, iupClass);
				item.Callbacks = GetCallbacks(classname, iupClass);

				DocEnricher.Enrich(docsPath, item);
				KnownAttributes.Enrich(item);

				if (item.Attributes.Any(x => x.DataType == DataType.Void && !x.WriteOnly)) throw new InvalidOperationException("Cannot read \"void\" atributes");
				result.Add(item);
			}

			return result.ToArray();
		}

		private static IupAttribute[] GetAttributes(IntPtr classname, Interop.IClass iupClass)
		{
			var attributes = new List<IupAttribute>();

			var attrs = new IntPtr[BUFFER_SIZE];
			var count = Interop.IupGetClassAttributes(classname, attrs, BUFFER_SIZE);

			for (int i = 0; i < count; i++)
			{
				var name = Marshal.PtrToStringAnsi(attrs[i]);

				var attrHandle = Interop.iupTableGet(iupClass.attrib_func, name);
				var attrData = Marshal.PtrToStructure<Interop.IAttribFunc>(attrHandle);

				var flags = (Interop.IAttribFlags)attrData.flags;
				var isNoString = flags.HasFlag(Interop.IAttribFlags.IUPAF_NO_STRING);

				var numberedAttributeType =
					flags.HasFlag(Interop.IAttribFlags.IUPAF_HAS_ID) ? NumberedAttribute.OneID :
					flags.HasFlag(Interop.IAttribFlags.IUPAF_HAS_ID2) ? NumberedAttribute.TwoIDs :
					NumberedAttribute.No;

				var attribute = new IupAttribute
				{
					AttributeName = name,
					Name = UpperCaseConverter.ToTitleCase(name),
					WriteOnly = flags.HasFlag(Interop.IAttribFlags.IUPAF_WRITEONLY),
					ReadOnly = flags.HasFlag(Interop.IAttribFlags.IUPAF_READONLY),
					Default = attrData.default_value,
					DataType = isNoString ? DataType.Unknown : DataType.String,
					NumberedAttribute = numberedAttributeType,
				};

				attributes.Add(attribute);
			}

			return attributes.ToArray();
		}

		private static IupCallback[] GetCallbacks(IntPtr classname, Interop.IClass iupClass)
		{
			var callbacks = new List<IupCallback>();

			var attrs = new IntPtr[BUFFER_SIZE];
			var count = Interop.IupGetClassCallbacks(classname, attrs, BUFFER_SIZE);
			for (int i = 0; i < count; i++)
			{
				var name = Marshal.PtrToStringAnsi(attrs[i]);

				var attrHandle = Interop.iupTableGet(iupClass.attrib_func, name);
				var attrData = Marshal.PtrToStructure<Interop.IAttribFunc>(attrHandle);

				var isCallback = ((Interop.IAttribFlags)attrData.flags).HasFlag(Interop.IAttribFlags.IUPAF_CALLBACK);
				if (!isCallback) return null;

				var format = attrData.default_value;
				var (arguments, returnType) = DecodeFormat(format);

				var callback = new IupCallback
				{
					AttributeName = name,
					Name = UpperCaseConverter.ToTitleCase(name.Replace("_CB", "")),
					Arguments = arguments,
					ReturnType = returnType
				};

				callbacks.Add(callback);
			}

			return callbacks.ToArray();
		}

		public static (DataType[], DataType) DecodeFormat(string format)
		{
			DataType getType(char c)
			{
				return c switch
				{
					'n' => DataType.Handle,
					'i' => DataType.Int,
					'I' => DataType.RefInt,
					's' => DataType.String,
					'd' => DataType.Double,
					'f' => DataType.Float,
					'v' or 'V' => DataType.VoidPtr,
					'c' => DataType.Char,
					'C' => DataType.Canvas,
					_ => throw new NotImplementedException($"Element {c} not recognized on format {format}"),
				};
			}

			var parts = format.Split('=');

			var args = parts[0].Select(c => getType(c)).ToArray();
			var returnType = parts.Length > 1 ? getType(parts[1][0]) : DataType.Void;

			return (args, returnType);
		}

		#endregion Methods
	}
}