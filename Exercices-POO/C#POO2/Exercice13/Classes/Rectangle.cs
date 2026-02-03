using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice13.Classes
{
    public class Rectangle
    {
        public double Longeur { get; set; }
        public double Height { get; set; }

        public Rectangle(double longeur, double largeur, double x = 0, double y = 0) : base(x, y)
        {
            if (longeur < 0 || largeur <= 0)
                throw new ArgumentException("Longeur et largeur doivent être positives");

            longeur = longueur;
            largeur = largeur;
        }

        public override string ToString()
        {
            return ($"Rectangle à pour origine = {Origine} et longeur = {Longeur} x 1 = {Largeur}");
        }
    }
}
