using System;
using System.Runtime.InteropServices;

namespace IupMetadata
{
	public static class Interop
	{
		#region InnerTypes

		[StructLayout(LayoutKind.Sequential)]
		public struct IClass
		{
			public string name;
			public string cons;
			public string format;
			public string format_attr;
			public int nativetype;
			public int childtype;
			public int is_interactive;
			public int has_attrib_id;
			public int is_internal;
			public int unknown1;
			public IntPtr parent;
			public IntPtr attrib_func;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct IAttribFunc
		{
			public IntPtr get;
			public IntPtr set;
			public string default_value;
			public string system_default;
			public int call_global_default;
			public int flags;
		}

		public enum IAttribFlags : int
		{
			IUPAF_DEFAULT = 0,     /**< inheritable, can has a default value, is a string, can call the set/get functions only if mapped, no ID */
			IUPAF_NO_INHERIT = 1,  /**< is not inheritable */
			IUPAF_NO_DEFAULTVALUE = 2,  /**< can not has a default value */
			IUPAF_NO_STRING = 4,   /**< is not a string */
			IUPAF_NOT_MAPPED = 8,  /**< will call the set/get functions also when not mapped */
			IUPAF_HAS_ID = 16,     /**< can has an ID at the end of the name, automatically set by \ref iupClassRegisterAttributeId */
			IUPAF_READONLY = 32,   /**< is read-only, can not be changed */
			IUPAF_WRITEONLY = 64,  /**< is write-only, usually an action */
			IUPAF_HAS_ID2 = 128,   /**< can has two IDs at the end of the name, automatically set by \ref iupClassRegisterAttributeId2 */
			IUPAF_CALLBACK = 256,  /**< is a callback, not an attribute */
			IUPAF_NO_SAVE = 512,   /**< can NOT be directly saved, should have at least manual processing */
			IUPAF_NOT_SUPPORTED = 1024,  /**< not supported in that driver */
			IUPAF_IHANDLENAME = 2048,    /**< is an Ihandle* name, associated with IupSetHandle */
			IUPAF_IHANDLE = 4096         /**< is an Ihandle* */
		}

		#endregion InnerTypes

		#region Fields

		#if Linux
		private const string IUP_DLL = "libiup.so";
		private const string IUP_CONTROLS_DLL = "libiupcontrols.so";
		#else
		private const string IUP_DLL = "libs/iup.dll";

		private const string IUP_CONTROLS_DLL = "libs/iupcontrols.dll";

		#endif

		#endregion Fields

		#region Methods

		[DllImport(IUP_DLL)]
		public static extern int IupOpen(IntPtr argc, IntPtr argv);

		[DllImport(IUP_CONTROLS_DLL)]
		public static extern int IupControlsOpen();

				[DllImport(IUP_CONTROLS_DLL)]
		public static extern IntPtr IupMatrix();

		[DllImport(IUP_DLL)]
		public static extern int IupGetAllClasses(IntPtr[] buffer, int n);

		[DllImport(IUP_DLL)]
		public static extern int IupGetClassAttributes(IntPtr classname, IntPtr[] buffer, int n);

		[DllImport(IUP_DLL)]
		public static extern int IupGetClassCallbacks(IntPtr classname, IntPtr[] buffer, int n);

		[DllImport(IUP_DLL)]
		public static extern IntPtr IupGetAttributeHandle(IntPtr ih, IntPtr name);

		[DllImport(IUP_DLL)]
		public static extern IntPtr IupCreate(IntPtr classname);

		[DllImport(IUP_DLL)]
		public static extern IntPtr iupRegisterFindClass(IntPtr classname);

		[DllImport(IUP_DLL)]
		public static extern IntPtr iupTableGet(IntPtr it, string key);

		#endregion Methods
	}
}