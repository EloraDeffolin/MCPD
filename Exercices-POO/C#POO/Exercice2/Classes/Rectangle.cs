using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2.Classes
{
    internal class Rectangle
    {
   
        public double Largeur 

        { get; set; }

        public double Hauteur
        
        { get; set; }

        public double Perimetre()
        {
            return 2 * (Largeur + Hauteur);
        }

        public double Surface()
        {
            return Largeur * Hauteur;
        }
    }




}
