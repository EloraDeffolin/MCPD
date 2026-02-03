using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice13.Classes
{
    public class Point
    {
        public double PosX { get; set; }
        public double PosY { get; set; }

        public Point (double x = 0, double y = 0)
        {
            PosX = x;
            PosY = y;
        }

        public override string ToString()
        {
            return ($"{PosX} , {PosY}");
        }
    }
}
