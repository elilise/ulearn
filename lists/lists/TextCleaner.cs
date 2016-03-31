using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lists
{
	class TextCleaner
	{
		public static List<string> SplitOnSenteces(string text)
		{
			var separator = new char[] { '.', '!','?', ';', ':', ')', '(', '-', '"' };
			return text.Split(separator)
				.Select(sentence => sentence.ToLower())
				.ToList();
		}

		public static ILookup<string,int> GroupWords(List<string> text)
		{
			var allWordsInText = new List<string>();
			foreach (var words in text.Select(line => line.Split(' ', ',', '-')))
			{
				allWordsInText.AddRange(words);
			}

			return allWordsInText
				.OrderBy(word => word)
				.GroupBy(word => word)
				.ToLookup(group => group.Key, group => group.Count());
		}
	}
}
