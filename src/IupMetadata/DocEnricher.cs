using System.IO;
using System.Linq;
using System.Text;

namespace IupMetadata
{
	public static class DocEnricher
	{
		#region Methods

		#region Documentation

		/// <summary>
		/// Text-scrap inside the HTML documentation to extract the text for classes, attributes and callbacks
		/// It uses a copy of the oficial documentation, found at IUP's sourcefoge repository
		/// https://iweb.dl.sourceforge.net/project/iup/3.30/Docs%20and%20Sources/iup-3.30_Docs_html.tar.gz
		/// </summary>

		#endregion Documentation

		public static void Enrich(string docsPath, IupClass item)
		{
			var path = GetPath(docsPath, item);
			if (!File.Exists(path)) return;

			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.Load(path);

			var title = doc.DocumentNode.Descendants("h2").FirstOrDefault();
			var builder = new StringBuilder();
			var next = title.NextSibling;

			//Skips the header of the HTLM documentation
			//All attributes/callbacks are placed inside a "h" tag, i.e. <h2>

			for (; ; )
			{
				if (next.Name.StartsWith("h")) break;
				builder.Append(next.InnerText);
				next = next.NextSibling;
			}

			item.Documentation = Normalize(builder.ToString());
			EnrichAttributes(item, next);

			foreach (var callback in item.Callbacks)
			{
				EnrichCallbacks(docsPath, callback);
			}
		}

		private static void EnrichAttributes(IupClass item, HtmlAgilityPack.HtmlNode next)
		{
			// Find the "Attributes" section
			// All attributes are placed inside <h> tag
			// Sometimes many attributes have the same documentation

			for (; ; )
			{
				if (next == null) return;
				if (next.Name.StartsWith("h") && next.InnerText == "Attributes") break;
				next = next.NextSibling;
			}

			for (; ; )
			{
				if (next == null) return;

				string[] attributeNames;
				for (; ; )
				{
					if (next.Name == "p")
					{
						var firstChild = next.FirstChild;
						for (; ; )
						{
							var value = Normalize(firstChild.InnerText);
							if (!string.IsNullOrEmpty(value))
							{
								attributeNames = value.Split(',').Select(x => x.Trim()).ToArray();
								break;
							}
							else
							{
								firstChild = firstChild.NextSibling;
							}
						}

						break;
					}
					else
					{
						next = next.NextSibling;
					}
				}

				var builder = new StringBuilder();
				for (; ; )
				{
					if (next.Name.StartsWith("h")) return;

					builder.Append(next.InnerText);
					next = next.NextSibling;
					if (next == null || next.Name == "p") break;
				}

				var doc = Normalize(builder.ToString());
				bool isCreationOnly = doc.Contains("creation only");

				foreach (var attributeName in attributeNames)
				{
					var attribute = item.Attributes.FirstOrDefault(x => x.AttributeName == attributeName);
					if (attribute != null)
					{
						attribute.Documentation = doc;
						attribute.CreationOnly = isCreationOnly;
					}
				}
			}
		}

		private static void EnrichCallbacks(string docsPath, IupCallback iupCallback)
		{
			var path = docsPath + $"/en/call/iup_{iupCallback.AttributeName.ToLower()}.html";
			if (!File.Exists(path)) return;

			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.Load(path);

			iupCallback.Documentation = Normalize(doc.DocumentNode.InnerText);
		}

		private static string Normalize(string str)
		{
			// TODO: Improve this code

			for (; ; )
			{
				var normalized = str
					.Replace("\t", " ")
					.Replace("\r", "")
					.Replace("\n", " ")
					.Replace("&nbsp;", " ")
					.Replace("&quot;", "\"")
					.Replace("&amp;", "&")
					.Replace("&gt;", ">")
					.Replace("&lt;", "<")
					.Replace("  ", " ")
					.Replace("�", "")
					.Trim();

				if (normalized == str)
				{
					return str;
				}
				else
				{
					str = normalized;
				}
			}
		}

		private static string GetPath(string docsPath, IupClass item)
		{
			return item.NativeType switch
			{
				NativeType.Dialog => docsPath + $"/en/dlg/iup{item.ClassName}.html",
				_ => docsPath + $"/en/elem/iup{item.ClassName}.html",
			};
		}

		#endregion Methods
	}
}