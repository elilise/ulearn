using System;
using System.Linq;

namespace names
{
	internal class NamesTasks
	{
		// Пример подготовки данных для построения графиков:
		public static void ShowBirthYearsStatisticsHistogram(NameData[] names)
		{
			/*
			Подготовка данных для построения гистограммы 
			— количества людей в выборке в зависимости от года их рождения.
			*/

			Console.WriteLine("Статистика рождаемости по годам");
			var minYear = int.MaxValue;
			var maxYear = int.MinValue;
			foreach (var name in names)
			{
				minYear = Math.Min(minYear, name.BirthDate.Year);
				maxYear = Math.Max(maxYear, name.BirthDate.Year);
			}
			var years = new string[maxYear - minYear + 1];
			for (int y = 0; y < years.Length; y++)
				years[y] = (y + minYear).ToString();
			var birthsCounts = new double[maxYear - minYear + 1];
			foreach (var name in names)
				birthsCounts[name.BirthDate.Year - minYear]++;

			Charts.ShowHistorgam("Рождаемость по годам", years, birthsCounts);
		}

		public static void ShowBirthDaysOfName(NameData[] names, string name)
		{
			/*
			Напишите код, готовящий данные для построения гистограммы 
			— количества людей в выборке c заданным именем в зависимости от числа (то есть номера дня в месяце) их рождения.
			Не учитывайте тех, кто родился 1 числа любого месяца.
			Если вас пугает незнакомое слово гистограмма — вам как обычно в википедию! 
			http://ru.wikipedia.org/wiki/%D0%93%D0%B8%D1%81%D1%82%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B0
			Посмотрите пример выше с годами рождения.

			Объясните наблюдаемый результат!
			*/

			//Charts.ShowHistorgam("Рождаемость людей с именем '" + name +"'", ..., ...);
		}

		public static void ShowBirthDateStatistics(NameData[] names)
		{
			Console.WriteLine("Статистика рождаемости по датам");
			/*
			Подготовьте данные для построения карты интенсивностей, у которой по оси X — число месяца, по Y — номер месяца, 
			а интенсивность точки (она отображается цветом и размером) обозначает количество рожденных людей в это число этого месяца.

			Подберите формулу перевода количества родившихся в интенсивность точки так, чтобы было хорошо видно, что 8 марта и 23 февраля рождаются чаще, чем в среднем.
			Эта формула не обязательно должна быть линейной. Поэкспериментируйте!

			*/
			// Charts.ShowHeatmap("Пример карты интенсивностей", new double[,] {{1, 2, 3}, {2, 3, 4}, {3, 4, 4}, {4, 4, 4}}, 1, 1);
		}

		public static void ShowYourStatistics(NameData[] names)
		{
			/*
			Придумайте и изучите какую-нибудь статистику про имена рождающихся людей.
			То, получите ли вы балл за эту задачу завивисит от интересности и нетривиальности результата и оставляется на усмотрение преподавателя.
			Эта задача принимается только если предыдущие приняты.
			*/
		}
	}
}
