using System;
using System.Collections.Generic;

namespace Livre
{
	 class Livre
	{
		public int Numero { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int ExemplairesDisponibles { get; set; }

        public Livre(int numero, string titre, string auteur, int exemplaires)
        {
            Numero = numero;
            Titre = titre?.Trim() ?? "Inconnu";
            Auteur = auteur?.Trim() ?? "Inconnu";
            ExemplairesDisponibles = Math.Max(0, exemplaires);
        }

        public override string ToString()
        {
            return $"#{Numero,-4} | {Titre,-35} | {Auteur,-25} | Dispo: {ExemplairesDisponibles,3}";
        }
    }
}
