using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1.Classes
{
    internal class Chaise
    {
        private int _nbPieds;
        private string _materiaux;
        private string _couleurObjet;

        private int NombrePieds
        {
            get { return NombrePieds; }
            set { _nbPieds = value >= 0 ? value : 4; }
        }

        private string NomMateriaux
        {
            get { return NomMateriaux ?? "Inconnu"; }
            set { _materiaux = value; }
        }

        private string CouleurObjet
        {
            get { return CouleurObjet ?? "Inconnu"; }  
            set { _couleurObjet = value; }
        }

        public bool IsStarted { get; set; } = false;

        public Chaise() { }
        public Chaise(int nbPieds, string mat, string col)
        {
            NombrePieds = 4;
            NomMateriaux = "Plastique";
            CouleurObjet = "Noir";
        }

        public override string ToString()
        {
            return $"La Chaise à {NombrePieds} pieds. La Matière est {NomMateriaux} et la couleur est {CouleurObjet}";
        }
    }
}


