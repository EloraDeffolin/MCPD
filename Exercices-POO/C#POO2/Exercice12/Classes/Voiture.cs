using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice12.Classes
{
    public class Voiture : vehicule, Motorise
    {
        public Voiture(string nom, string marque) : base(nom, marque) { }

        public void Demarrer()
        {
            Console.WriteLine($"{Nom} démarre.");
        }
    }
}
