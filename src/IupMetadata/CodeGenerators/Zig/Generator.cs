using System.Diagnostics;
using System.Text;
using System.Linq;

namespace IupMetadata.CodeGenerators.Zig
{
	public static class Generator
	{
		#region Methods

		public static void Generate(string basePath, IupClass[] metadata)
		{
			ElementsGenerator.Generate(basePath, metadata);

			foreach (var item in metadata)
			{
				var parentAttributes = GetParentAttributes(metadata, item);
				ElementGenerator.Generate(basePath, item, parentAttributes);
			}
		}

		private static IupAttribute[] GetParentAttributes(IupClass[] metadata, IupClass item)
		{
			return metadata
					.SelectMany(x => x.Attributes)
					.Where(x => x.AtChildrenOnly)
					.Where(x => x.TargetChildren == null || x.TargetChildren.Any(y => y == item.NativeType))
					.Where(x => !item.Attributes.Any(y => string.Equals(y.Name, x.AttributeName, System.StringComparison.InvariantCultureIgnoreCase)))
					.GroupBy(x => x.AttributeName)
					.Select(x => x.First())
					.ToArray();
		}

		internal static string GetDocumentation(string text)
		{
			if (string.IsNullOrEmpty(text)) return null;

			const int COLUMNS = 80;
			var builder = new StringBuilder();
			builder.AppendLine("/// ");
			builder.Append(WordWrap.Wrap(text, COLUMNS, "/// "));

			return builder.ToString();
		}

		internal static void Fmt(string path)
		{
			//TODO: Add linux suport
			var startInfo = new ProcessStartInfo
			{
				FileName = "zig.exe",
				Arguments = $"fmt {path}",
			};

			var process = Process.Start(startInfo);
			process.WaitForExit();
		}

		#endregion Methods
	}
}