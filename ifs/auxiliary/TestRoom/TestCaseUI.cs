using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TestingRoom
{
	public class TestCaseUI : IDisposable
	{
		private readonly Bitmap image;
		private readonly TextBox logTextBox;
		private readonly Graphics g;

		public TestCaseUI(Bitmap image, TextBox logTextBox)
		{
			this.image = image;
			this.logTextBox = logTextBox;
			g = Graphics.FromImage(image);
			g.SmoothingMode = SmoothingMode.HighQuality;
		}

		public void Log(string text)
		{
			logTextBox.Text += text + "\r\n";
		}

		public void Log(string textFormat, params object[] args)
		{
			logTextBox.Text += string.Format(textFormat, args) + "\r\n";
		}

		public void Circle(double x, double y, double r, Pen pen)
		{
			g.DrawEllipse(pen, ConvX(x - r), ConvY(y - r), Scale(2 * r), Scale(2 * r));
		}

		public void Arc(double x, double y, double r, double startAngle, double sweepAngle, Pen pen)
		{
			g.DrawArc(pen, ConvX(x-r), ConvY(y-r), Scale(2*r), Scale(2*r), (float)startAngle, (float)sweepAngle);
		}

		private float Scale(double logicalCoord)
		{
			return (float)(Math.Min(image.Width, image.Height) * logicalCoord / 200);
		}
		private float ConvX(double logicalX)
		{
			return 0.5f * image.Width + Scale(logicalX);
		}

		private float ConvY(double logicalY)
		{
			return 0.5f * image.Height+ Scale(logicalY);
		}

		public void Dot(double x, double y, Color color)
		{
			var xx = (int) ConvX(x);
			var yy = (int) ConvY(y);
			if (xx >= 0 && xx < image.Width && yy >= 0 && yy < image.Height)
				image.SetPixel(xx, yy, color);
		}

		public void Line(double x1, double y1, double x2, double y2, Pen pen)
		{
			g.DrawLine(pen, ConvX(x1), ConvY(y1), ConvX(x2), ConvY(y2));
		}

		public void Dispose()
		{
			g.Dispose();
		}

		public void Rect(Rectangle r, Pen pen)
		{
			g.DrawRectangle(pen, ConvX(r.Left), ConvY(r.Top), Scale(r.Width), Scale(r.Height));
		}
	}
}