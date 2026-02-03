using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice12.Interfaces;

namespace Exercice12.Classes
{
    public class Hydravion : vehicule, Motorise, Volant, Flottant
    {
        public Hydravion(string nom, string marque) : base(nom, marque) { }
        
        public void Demarrer()
        {
            Console.WriteLine($"{Nom} démarre ses moteurs.");
        }

        public void Decoller()
        {
            Console.WriteLine($"{Nom} décolle");
        }

        public void Atterir()
        {
            Console.WriteLine($"{Nom} atterit sur l'eau.");
        }

        public void Naviguer()
        {
            Console.WriteLine($"{Nom} navigue sur l'eau.");
        }


    }
}
