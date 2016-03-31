using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    public class Line
    {
        public int X0;
        public int Y0;
        public int X1;
        public int Y1;
        public Line(int x0, int y0, int x1, int y1)
        {
            X1 = x1;
            X0 = x0;
            Y1 = y1;
            Y0 = y0;
        }
    }
}
