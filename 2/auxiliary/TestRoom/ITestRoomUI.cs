using System.Drawing;

namespace TestingRoom
{
	public interface ITestRoomUI
	{
		void Circle(double x, double y, double r, Color color);
		void Dot(double x, double y, Color color);
		void Line(double x1, double y1, double x2, double y2, Color color);
	}
}