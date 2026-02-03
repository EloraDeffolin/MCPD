using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice12.Classes
{
    public abstract class vehicule
    {
        public string Nom { get; set; }
        public string Marque { get; set; }

        protected vehicule(string nom, string marque)
        {
            Nom = nom;
            Marque = marque;
        }

        public override string TotString()
        {
            return $"Véhicule : {Nom}, Marque : {Marque}";
        }
        
    }
}
