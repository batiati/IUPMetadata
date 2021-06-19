using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IupMetadata
{
	#region Documentation

	/// <summary>
	/// Converts the UPPERCASE without snakes to TitleCase based on a dictionary to split words
	/// </summary>

	#endregion Documentation

	public static class UpperCaseConverter
	{
		#region InnerTypes

		private class WordMap
		{
			public string Word { get; set; }

			public int StartIndex { get; set; }

			public int EndIndex
			{
				get
				{
					return StartIndex + Word.Length - 1;
				}
			}
		}

		#endregion InnerTypes

		#region Fields

		private static readonly HashSet<string> words = new HashSet<string>();
		private static readonly HashSet<string> suggestWords = new HashSet<string>();
		private static readonly Dictionary<string, string> processed = new Dictionary<string, string>();

		#endregion Fields

		#region Constructor

		static UpperCaseConverter()
		{
			foreach (var word in Resources.Dictionary.dictionary.Split(Environment.NewLine))
			{
				if (string.IsNullOrEmpty(word) || word.StartsWith("#")) continue;
				words.Add(word);
			}
		}

		#endregion Constructor

		#region Methods

		public static string ToTitleCase(string value)
		{
			var word = value.Replace("_", "").ToLower();
			if (!processed.TryGetValue(word, out string newName))
			{
				var buffer = new StringBuilder();
				buffer.Append(word);

				// Selecting all words contained on the string
				var fitWordMaps = words.Concat(suggestWords).Select(x => new WordMap { Word = x, StartIndex = word.IndexOf(x) }).Where(x => x.StartIndex >= 0).ToArray();

				// Calculating colisions between words, like "user" and "use", remove the shortest
				var colisions = GetColisions(fitWordMaps);
				fitWordMaps = fitWordMaps.Except(colisions).ToArray();

				// In case of colision, prefer the longest word
				fitWordMaps = fitWordMaps.GroupBy(x => x.StartIndex).Select(x => x.OrderByDescending(y => y.EndIndex).First()).OrderBy(x => x.StartIndex).ToArray();

				int currentIndex = 0;

				foreach (var wordMap in fitWordMaps)
				{
					if (wordMap.StartIndex > currentIndex)
					{
						string suggestWord = word.Substring(currentIndex, wordMap.StartIndex - currentIndex);
						if (suggestWord.Length > 3) suggestWords.Add(suggestWord);

						Replace(buffer, currentIndex, Capitalize(suggestWord));
					}

					currentIndex = wordMap.StartIndex;

					Replace(buffer, currentIndex, Capitalize(wordMap.Word));

					currentIndex += wordMap.Word.Length;
					if (currentIndex >= word.Length) break;
				}

				if (currentIndex < word.Length - 1)
				{
					string suggestWord = word.Substring(currentIndex);
					if (suggestWord.Length > 3) suggestWords.Add(suggestWord);

					Replace(buffer, currentIndex, Capitalize(suggestWord));
				}

				newName = buffer.ToString();
				processed.Add(word, newName);
			}

			if (!word.Equals(newName, StringComparison.InvariantCultureIgnoreCase)) throw new InvalidOperationException();

			return newName;
		}

		private static WordMap[] GetColisions(WordMap[] fitWordMaps)
		{
			var colisions = new List<WordMap>();

			foreach (var wordMap in fitWordMaps.OrderBy(x => x.StartIndex).ThenByDescending(x => x.Word.Length))
			{
				if (colisions.Contains(wordMap)) continue;

				var selections = fitWordMaps.Except(colisions).Where(x => wordMap != x && IsColision(wordMap, x)).ToArray();
				colisions.AddRange(selections);
			}

			return colisions.ToArray();
		}

		private static bool IsColision(WordMap right, WordMap left)
		{
			bool hasColision = IsBetween(left.StartIndex, right.StartIndex, right.EndIndex) || IsBetween(left.EndIndex, right.StartIndex, right.EndIndex);
			return hasColision;
		}

		private static void Replace(StringBuilder buffer, int currentIndex, string word)
		{
			for (int i = 0; i < word.Length; i++)
			{
				buffer[currentIndex + i] = word[i];
			}
		}

		private static string Capitalize(string name)
		{
			if (name.Length > 1)
			{
				return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
			}
			else
			{
				return name.ToUpper();
			}
		}

		private static bool IsBetween(int value, int initial, int final)
		{
			return value >= initial && value <= final;
		}

		#endregion Methods
	}
}