using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Exercice2.Classes;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
           
            Rectangle monRectangle = new Rectangle();

            monRectangle.Largeur = 5;
            monRectangle.Hauteur = 3;

            Console.WriteLine("Périmètre : " + monRectangle.Perimetre());
            Console.WriteLine("Surface : " + monRectangle.Surface());

        }
    }
}