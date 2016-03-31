using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lists
{
	class Program
	{
		static void Main(string[] args)
		{
			var forProcessingFile = File.ReadAllText("text.txt");
			var textSentences = TextCleaner.SplitOnSenteces(forProcessingFile);
			var groupedWords = TextCleaner.GroupWords(textSentences);
			foreach (var group in groupedWords)
			{
				Console.WriteLine(group.Key);
			}
			
			Console.ReadKey();
		}
	}
}
