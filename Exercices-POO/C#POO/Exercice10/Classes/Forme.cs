using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice10.Classes
{
    internal class Forme
    {

     using System;

public abstract class Forme
    {
        public string Nom { get; set; }

        public Forme(string nom)
        {
            Nom = nom;
        }

        public abstract double CalculerAire();
        public abstract double CalculerPerimetre();

        public virtual void Infos()
        {
            Console.WriteLine($"Forme : {Nom}");
            Console.WriteLine($"Aire : {CalculerAire()}");
            Console.WriteLine($"Périmètre : {CalculerPerimetre()}");
         
        }
    }
}




