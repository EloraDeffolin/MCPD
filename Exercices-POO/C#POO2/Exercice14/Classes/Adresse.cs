using System;

public class Adresse
{
    public class Adresse()
    {
        public int NumeroRue { get; set; }
        public string NomRue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }

        public Adresse(int numeroRue, string nomRue, string ville, string codePostal)
        {
            NumeroRue = numeroRue;
            NomRue = nomRue ?? throw new ArgumentNullException(nameof(nomRue));
            Ville = ville ?? throw new ArgumentNullException(nameof(ville));
            CodePostal = codePostal ?? throw new ArgumentNullException(nameof(codePostal));
        }

        public override string ToString()
        {
            return $"Le numéro de rue est : {NumeroRue} , le nom de la rue {NomRue}, sont code postal {CodePostal} et sa {Ville} .";
        }
    }
}
