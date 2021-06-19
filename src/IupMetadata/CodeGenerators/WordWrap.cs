using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IupMetadata.CodeGenerators
{
	public static class WordWrap
	{
		#region Methods

		#region Documentation

		/// <summary>
		/// Wraps a text into multiple lines
		/// </summary>
		/// <param name="text">Text to wrap</param>
		/// <param name="lineLength">Desired line lenght</param>
		/// <param name="beginLine">Text to insert before each line</param>
		/// <returns></returns>

		#endregion Documentation

		public static string Wrap(string text, int lineLength, string beginLine = null)
		{
			using (var reader = new StringReader(text))
			{
				return string.Join(Environment.NewLine, ReadLines(reader, lineLength, beginLine));
			}
		}

		private static IEnumerable<string> ReadLines(TextReader reader, int lineLength, string beginLine)
		{
			var beginLen = string.IsNullOrEmpty(beginLine) ? 0 : beginLine.Length;
			var line = new StringBuilder();
			foreach (var word in reader.ReadWords())
			{
				var isEndOfPhrase = word.EndsWith('.') || word.EndsWith('\n');

				if (!isEndOfPhrase && beginLen + line.Length + word.Length < lineLength)
				{
					line.Append(word);
					line.Append(' ');
				}
				else
				{
					if (beginLen > 0) line.Insert(0, beginLine);

					if (isEndOfPhrase)
					{
						line.Append(word);
						yield return line.ToString().Trim();
						line.Clear();
					}
					else
					{
						yield return line.ToString().Trim();
						line.Clear();
						line.Append(word);
						line.Append(' ');
					}
				}
			}

			if (line.Length > 0)
			{
				if (beginLen > 0) line.Insert(0, beginLine);
				yield return line.ToString().Trim();
			}
		}

		private static IEnumerable<string> ReadWords(this TextReader reader)
		{
			while (!reader.IsEof())
			{
				var word = new StringBuilder();
				while (!reader.IsBreak())
				{
					word.Append(reader.Text());
					reader.Read();
				}

				reader.Read();
				if (word.Length > 0)
				{
					yield return word.ToString();
				}
			}
		}

		private static bool IsBreak(this TextReader reader) => reader.IsEof() || reader.IsWhiteSpace();

		private static bool IsWhiteSpace(this TextReader reader) => string.IsNullOrWhiteSpace(reader.Text());

		private static string Text(this TextReader reader) => char.ConvertFromUtf32(reader.Peek());

		private static bool IsEof(this TextReader reader) => reader.Peek() == -1;

		#endregion Methods
	}
}