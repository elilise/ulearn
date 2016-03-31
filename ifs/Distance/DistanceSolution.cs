using System;

namespace DistanceTask
{
    public class DistanceSolution
    {
        // –ассто€ние от точки (x, y) до отрезка AB с координатами A(aX, aY), B(bX, bY)
	    public static double GetDistanceToSegment(double aX, double aY, double bX, double bY, double x, double y)
	    {
		    double distance;
		    double vectorComposition = (x - aX)*(bY - aY) - (y - aY)*(bX - aX);
		    if ((aY == aX) && (bY == bX))
			{
				distance = Math.Sqrt(Math.Pow(x - aX, 2) + Math.Pow(y - aY, 2));
			}
			else if (vectorComposition == 0)
		    {
			    if ((y - aY)/(bY - aY) == (x - aX)/(bX - aX))
			    {
				    distance = 0;
			    }
			    else
			    {
					distance = Math.Min(Math.Sqrt(Math.Pow(x - aX, 2) + Math.Pow(y - aY, 2)), Math.Sqrt(Math.Pow(x - bX, 2) + Math.Pow(y - bY, 2)));
			    }	
		    }
		    else
		    {
				distance = Math.Abs((aY - bY)*x + (bX - aX)*y + (aX*bY - bX*aY))/
	                          Math.Sqrt(Math.Pow(bX - aX, 2) + Math.Pow(bY - aY, 2));		    
		    }

            return distance;
        }
    }
}