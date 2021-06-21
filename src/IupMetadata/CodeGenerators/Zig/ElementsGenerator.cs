using Humanizer;
using System.IO;
using System.Text;

namespace IupMetadata.CodeGenerators.Zig
{
	internal static class ElementsGenerator
	{
		#region Methods

		public static void Generate(string basePath, IupClass[] metadata)
		{
			var template = Templates.elements;
			template = template.Replace("{{Imports}}", GetImports(metadata));
			template = template.Replace("{{UnionDecl}}", GetUnionDecl(metadata));
			template = template.Replace("{{FromType}}", GetFromType(metadata));
			template = template.Replace("{{FromRef}}", GetFromRef(metadata));
			template = template.Replace("{{FromClassName}}", GetFromClassName(metadata));
			template = template.Replace("{{GetHandle}}", GetHandle(metadata));
			template = template.Replace("{{Children}}", GetChildren(metadata));
			template = template.Replace("{{Deinit}}", GetDeinit(metadata));

			var path = Path.Combine(basePath, "elements.zig");
			File.WriteAllText(path, template);

			Generator.Fmt(path);
		}

		private static string GetImports(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				var fileName = item.Name.Underscore();
				builder.AppendLine($@"pub const {item.Name} = @import(""elements/{fileName}.zig"").{item.Name};");
			}

			return builder.ToString();
		}

		private static string GetUnionDecl(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				builder.AppendLine($"{item.Name}: *{item.Name},");
			}

			return builder.ToString();
		}

		private static string GetFromType(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				builder.AppendLine($"{item.Name}, *{item.Name} => return .{{ .{item.Name} = @ptrCast(*{item.Name}, handle) }},");
			}

			return builder.ToString();
		}

		private static string GetFromRef(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				builder.AppendLine($"{item.Name} => return .{{ .{item.Name} = reference }},");
			}

			return builder.ToString();
		}

		private static string GetFromClassName(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				builder.AppendLine($"if (ascii.eqlIgnoreCase(className, {item.Name}.CLASS_NAME)) return . {{ .{item.Name} = @ptrCast(*{item.Name}, handle) }};");
			}

			return builder.ToString();
		}

		private static string GetHandle(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				builder.AppendLine($".{item.Name} => |value| return @ptrCast(*Handle, value),");
			}

			return builder.ToString();
		}

		private static string GetChildren(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				if (item.ChildrenCount == 0) continue;
				builder.AppendLine($".{item.Name} => |value| return value.children(), ");
			}

			return builder.ToString();
		}

		private static string GetDeinit(IupClass[] metadata)
		{
			var builder = new StringBuilder();

			foreach (var item in metadata)
			{
				builder.AppendLine($".{item.Name} => |element| element.deinit(),");
			}

			return builder.ToString();
		}

		#endregion Methods
	}
}