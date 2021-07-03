using System;
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

			var document = new HtmlAgilityPack.HtmlDocument();
			document.Load(path);

			var title = document.DocumentNode.Descendants("h2").FirstOrDefault();
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
			// Find the "Attributes" or "Callbacks" section
			// All content sections are placed inside <h> tag
			// All attributes/callbacks names starts with <p> tag

			var sectionNames = new string[] { "attributes", "callbacks" };
			bool isAnySection(HtmlAgilityPack.HtmlNode node) => node != null && node.Name.StartsWith("h", StringComparison.InvariantCultureIgnoreCase);
			bool isContentSection(HtmlAgilityPack.HtmlNode node) => isAnySection(node) && sectionNames.Any(x => node.InnerText.StartsWith(x, StringComparison.InvariantCultureIgnoreCase));
			bool isAttribute(HtmlAgilityPack.HtmlNode node) => node != null && node.Name.Equals("p", StringComparison.InvariantCultureIgnoreCase);

			void findContentSection(ref HtmlAgilityPack.HtmlNode node, bool stopOnAttributes = true)
			{
				if (next == null) return;

				for (; ; )
				{
					if (isContentSection(next)) break;
					if (stopOnAttributes && isAttribute(node)) break;

					next = next.NextSibling;
					if (next == null) break;
				}
			}

			findContentSection(ref next, stopOnAttributes: false);

			for (; ; )
			{
				string[] attributeNames = null;

				for (; ; )
				{
					if (next == null) return;

					if (isAttribute(next))
					{
						var firstChild = next.FirstChild;

						for (; ; )
						{
							if (firstChild == null) break;
							if (firstChild.Name == "font")
							{
								firstChild = firstChild.FirstChild;
							}

							var value = Normalize(firstChild.InnerText);
							if (!string.IsNullOrEmpty(value))
							{
								// Sometimes many attributes have the same documentation
								// Split at ';' and ' '

								attributeNames = value.Split(',', ' ')
									.Select(x => x.Replace(":", "").Trim())
									.Where(x => !string.IsNullOrEmpty(x))
									.ToArray();
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

				if (attributeNames == null) break;

				var builder = new StringBuilder();

				for (; ; )
				{
					if (next == null) break;
					if (isAnySection(next)) break;

					builder.Append(next.InnerText);
					next = next.NextSibling;

					if (isAttribute(next)) break;
				}

				var documentation = Normalize(builder.ToString());
				bool isCreationOnly = documentation.Contains("creation only");
				bool atChildrenOnly = documentation.Contains("children only");

				foreach (var attributeName in attributeNames)
				{
					var attribute = item.Attributes.FirstOrDefault(x => x.AttributeName == attributeName);

					if (attribute == null && attributeName.Last() is 'n')
					{
						attribute = item.Attributes.FirstOrDefault(x => x.AttributeName == attributeName.Substring(0, attributeName.Length - 1));
					}

					if (attribute != null)
					{
						if (attribute.Documentation == null)
						{
							attribute.Documentation = documentation;
						}
						else
						{
							builder = new StringBuilder(attribute.Documentation);
							if (!attribute.Documentation.EndsWith('.')) builder.Append('.');
							builder.Append(' ');
							builder.Append(documentation);

							attribute.Documentation = builder.ToString();
						}
						
						attribute.CreationOnly = isCreationOnly;
						attribute.AtChildrenOnly = atChildrenOnly;
						continue;
					}

					var callback = item.Callbacks.FirstOrDefault(x => x.AttributeName == attributeName);

					if (callback != null)
					{
						callback.Documentation = documentation;
						continue;
					}
				}

				findContentSection(ref next, stopOnAttributes: true);
			}
		}

		private static void EnrichCallbacks(string docsPath, IupCallback iupCallback)
		{
			var path = docsPath + $"/en/call/iup_{iupCallback.AttributeName.ToLower()}.html";
			if (!File.Exists(path)) return;

			var document = new HtmlAgilityPack.HtmlDocument();
			document.Load(path);

			iupCallback.Documentation = Normalize(document.DocumentNode.InnerText);
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