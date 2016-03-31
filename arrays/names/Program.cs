using System;
using System.IO;
using System.Linq;
using System.Text;

namespace names
{
	public class Program
	{
		private const string dataFilePath = @"..\..\names.txt";

		private static void Main(string[] args)
		{
			NameData[] namesData = ReadData();
			NamesTasks.ShowBirthDateStatistics(namesData);
			Console.WriteLine();
			NamesTasks.ShowBirthYearsStatisticsHistogram(namesData);
			NamesTasks.ShowBirthDaysOfName(namesData, "юрий");
			NamesTasks.ShowBirthDaysOfName(namesData, "владимир");
			NamesTasks.ShowYourStatistics(namesData);
			Console.WriteLine();
		}


		private static NameData[] ReadData()
		{
			string[] lines = File.ReadAllLines(dataFilePath, Encoding.GetEncoding(1251));
			var names = new NameData[lines.Length];
			for (int i = 0; i < lines.Length; i++)
				names[i] = NameData.ParseFrom(lines[i]);
			return names;
		}

		// О! А это более короткая версия ReadData(). Она использует механизм языка под названием Linq
		// Вы можете познакомиться с ней самостоятельно: https://ulearn.azurewebsites.net/Course/Linq
		// Освоив LINQ решать задачи подобные NamesTasks становится гораздо проще и приятнее.
		// Но это уже другая история.
		private static NameData[] ReadData2()
		{
			return File.ReadLines(dataFilePath).Select(NameData.ParseFrom).ToArray();
		}

	}
}
