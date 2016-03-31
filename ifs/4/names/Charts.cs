using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace names
{
	class Charts
	{
		public static void ShowHistorgam(string title, string[] xLabels, double[] yValues)
		{
			// Графики строятся сторонней библиотекой ZedGraph. Документацию можно найти тут http://zedgraph.sourceforge.net/samples.html
			// Не бойтесь экспериментировать с кодом самостоятельно!

			var chart = new ZedGraphControl()
			{
				Dock = DockStyle.Fill
			};
			chart.GraphPane.Title.Text = title;
			chart.GraphPane.YAxis.Title.Text = "Y";
			chart.GraphPane.AddBar("", Enumerable.Range(0, yValues.Length).Select(i => (double)i).ToArray(), yValues, Color.Blue);
			chart.GraphPane.YAxis.Scale.MaxAuto = true;
			chart.GraphPane.YAxis.Scale.MinAuto = true;
			chart.GraphPane.XAxis.Type = AxisType.Text;
			chart.GraphPane.XAxis.Scale.TextLabels = xLabels;

			chart.AxisChange();
			// Form — это привычное нам окно программы. Это одна из главных частей подсистемы под названием Windows Forms http://msdn.microsoft.com/ru-ru/library/ms229601.aspx
			var form = new Form();
			form.Text = title;
			form.Size = new Size(800, 600);
			form.Controls.Add(chart);
			form.ShowDialog();
		}

		public static void ShowHeatmap(string title, double[,] heat, int xMin, int yMin)
		{
			var chart = new ZedGraphControl()
			{
				Dock = DockStyle.Fill
			};
			var maxHeat = heat.Cast<double>().Max();
			chart.GraphPane.Title.Text = title;
			chart.GraphPane.YAxis.Title.Text = "";
			var maxSize = Math.Max(heat.GetLength(0), heat.GetLength(1));
			for (int x = 0; x < heat.GetLength(0); x++)
				for (int y = 0; y < heat.GetLength(1); y++)
				{
					var value = heat[x, y];
					if (value > 1000) throw new ArgumentException("too large heat value " + value);
					var color = Color.FromArgb(255, 50, (int)(255 * value / maxHeat), 0);
					var lineItem = chart.GraphPane.AddCurve("", new double[] { x + xMin }, new double[] { y + yMin }, color);
					lineItem.Symbol.Type = SymbolType.Circle;
					lineItem.Symbol.Fill = new Fill(color);
					lineItem.Symbol.Size = (float)(600 * value / maxHeat / maxSize);
				}
			chart.GraphPane.YAxis.Scale.MaxAuto = true;
			chart.GraphPane.YAxis.Scale.MinAuto = true;
			chart.AxisChange();
			var form = new Form();
			form.Text = title;
			form.Size = new Size(800, 600);
			form.Controls.Add(chart);
			form.ShowDialog();

		}
	}
}