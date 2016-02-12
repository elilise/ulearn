using System;
using System.Drawing;

namespace Rectangles
{
	public class RectangleTasks
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			return true;
		}

		// Площадь пересечения прямоугольников
		public int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		public int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			return -1;
		}
	}
}