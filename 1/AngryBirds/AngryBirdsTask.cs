using System;

namespace AngryBirds
{
	public class AngryBirdsTask
	{
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public double FindSightAngle(double v, double distance)
		{
			var sightAngle = Math.Asin(distance*9.8/Math.Pow(v, 2))/2;
			return sightAngle;
		}
	}
}
