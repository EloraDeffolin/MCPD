using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice13.Classes
{
    public class Triangle : Figure
    { 
        public double Base { get; set; }
        public double Hauteur { get; set; }

        public Triangle(double base, double hauteur, double x = 0, double y = 0) : base(x, y)
        {
            if (base <= 0 || hauteur <= 0)
                throw new ArgumentException("Base et hauteur doivent être ^positives");

            Base = base;
            Hauteur = hauteur;
        }

        public override string ToString()
        {
            return ($"Triangle à pour origine = {Origine} et une base = {Base} et une hauteur de {Hauteur} (isocèle)");
        }
    }
}
