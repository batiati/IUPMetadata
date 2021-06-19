using System.Diagnostics;
using System.Text;

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
				ElementGenerator.Generate(basePath, item);
			}
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