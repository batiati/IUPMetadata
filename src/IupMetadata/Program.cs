using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace IupMetadata
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("IUP Metadata exporter");
			Console.WriteLine("https://webserver2.tecgraf.puc-rio.br/iup/");

			#if Linux
			const string docsPath = @"./docs";
			const string jsonPath = @"./iup.json";
			const string zigPath = @"../IUPforZig/src";
			#else
			const string docsPath = @"../docs";
			const string jsonPath = @"../iup.json";
			const string zigPath = @"../../IUPforZig/src";
			#endif
			var metadata = MetadataExtractor.GetClasses(docsPath);

			Console.WriteLine("Writing JSON output: {0}", Path.GetFullPath(jsonPath));
			SaveAsJson(jsonPath, metadata);

			Console.WriteLine("Generating Zig output: {0}", Path.GetFullPath(zigPath));
			CodeGenerators.Zig.Generator.Generate(zigPath, metadata);

			Console.WriteLine("Done");
		}

		static void SaveAsJson(string path, IupClass[] metadata)
		{
			var settings = new JsonSerializerSettings();
			settings.Converters.Add(new StringEnumConverter());
			settings.Formatting = Formatting.Indented;

			var serializer = JsonSerializer.Create(settings);
			using (var file = new StreamWriter(path, append: false))
			{
				serializer.Serialize(file, metadata);
			}
		}
	}
}