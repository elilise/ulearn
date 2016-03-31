using System;

namespace names
{
	public class NameData
	{
		/// <summary>Дата рождения</summary>
		public DateTime BirthDate;

		/// <summary>Имя</summary>
		public string Name;

		public static NameData ParseFrom(string textLine)
		{
			string[] parts = textLine.Split('\t');
			return new NameData
				{
					BirthDate = DateTime.Parse(parts[0]),
					Name = parts[1],
				};
		}

		public override string ToString()
		{
			return string.Format("{0}\t{1}", BirthDate.ToString("dd.MM.yyyy"), Name);
		}
	}
}