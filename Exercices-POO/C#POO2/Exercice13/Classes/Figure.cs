using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice13.Interfaces;

namespace Exercice13.Classes
{
    public abstract class Figure : IDeplacable

    {
        public Point Origine { get; protected set; }

        protected Figure (double x =0, double y = 0)
        {
            Origine = new Point(x, y);
        }

        public void Deplacement(double dx, double dy)
        {
            Origine.PosX += dx;
            Origine.PosY += dy;
        }

        public abstract override string ToString();
    }
}
