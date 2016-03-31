using System;
using System.Drawing;
using System.Windows.Forms;

namespace Recognizer
{
    static class Program
    {
        const int ResizeRate = 2;

        static Bitmap ConvertToBitmap(int width, int height, Func<int, int, Color> getPixelColor)
        {
            var bmp = new Bitmap(ResizeRate * width, ResizeRate * height);
            using (var g = Graphics.FromImage(bmp))
            {
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                        g.FillRectangle(new SolidBrush(getPixelColor(x, y)),
                            ResizeRate * x,
                            ResizeRate * y,
                            ResizeRate,
                            ResizeRate
                            );
            }
            return bmp;
        }

        static Bitmap ConvertToBitmap(byte[,,] array)
        {
            return ConvertToBitmap(array.GetLength(0), array.GetLength(1), (x, y) => Color.FromArgb(array[x, y, 0], array[x, y, 1], array[x, y, 2]));
        }

        static Bitmap ConvertToBitmap(double[,] array)
        {
            return ConvertToBitmap(array.GetLength(0), array.GetLength(1), (x, y) =>
            {
                var gray = (int)(255 * array[x, y]);
                gray = Math.Min(gray, 255);
                gray = Math.Max(gray, 0);
                return Color.FromArgb(gray, gray, gray);
            });

        }

        static PictureBox CreateBox(Bitmap bmp)
        {
            return new PictureBox
            {
                Size = bmp.Size,
                Dock = DockStyle.Fill,
                Image = bmp
            };
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var bmp = (Bitmap)Image.FromFile("eurobot.bmp");
            var pixels = new byte[bmp.Width, bmp.Height, 3];
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    var pixel = bmp.GetPixel(x, y);
                    pixels[x, y, 0] = pixel.R;
                    pixels[x, y, 1] = pixel.G;
                    pixels[x, y, 2] = pixel.B;
                }

            var form = new Form
            {
                ClientSize = new Size(3*ResizeRate*bmp.Width, 2*ResizeRate*bmp.Height)
            };


            var panel = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 3,
                Dock = DockStyle.Fill
            };
            form.Controls.Add(panel);

            panel.Controls.Add(CreateBox(ConvertToBitmap(pixels)), 0, 0);
            Tasks.ClearNoise(pixels);
            panel.Controls.Add(CreateBox(ConvertToBitmap(pixels)), 1, 0);
            var grayscale = Tasks.Grayscale(pixels);
            panel.Controls.Add(CreateBox(ConvertToBitmap(grayscale)), 2, 0);
            var sobell = Tasks.SobelFiltering(grayscale);
            panel.Controls.Add(CreateBox(ConvertToBitmap(sobell)), 0, 1);
            Tasks.ThresholdFiltering(sobell);
            panel.Controls.Add(CreateBox(ConvertToBitmap(sobell)), 1, 1);

            var bitmap = ConvertToBitmap(sobell);
            using (var g = Graphics.FromImage(bitmap))
            {
                var lines = Tasks.HoughAlgorithm(sobell);
                var pen = new Pen(Color.Red, 2);
                foreach (var e in lines)
                    g.DrawLine(pen, e.X0 * ResizeRate, e.Y0 * ResizeRate, e.X1 * ResizeRate, e.Y1 * ResizeRate);
            }
            panel.Controls.Add(CreateBox(bitmap), 2, 1);
            Application.Run(form);
        }
    }
}
