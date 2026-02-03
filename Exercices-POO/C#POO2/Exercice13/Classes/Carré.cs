using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice13.Classes
{
    public class Triangle
    {
        public double Cote { get; set; }

        public Carré(double cote, double x = 0, double y = 0) : base(x, y)
        {
            if (cote <= 0) throw new ArgumentException("Le côté doit être positif.");

            Cote = cote;
        }

        public override string ToString()
        {
            return ($"Carré, origine = {Origine} et côté {Cote}");
        }
    }
}