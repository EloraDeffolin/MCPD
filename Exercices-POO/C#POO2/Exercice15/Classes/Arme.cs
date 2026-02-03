using System;


namespace CPOO.Classes
{
    internal class Arme

    {
        public string Nom { get; private set; }
        public int DegatSupplementaire { get; private set; }
        public int Durabilite { get; private set; }
        public bool EstCasse => Durabilite <= 0;

        public Arme(string nom, int degatSupp, int durabilite)
        {
            Nom = nom ?? "Main nue";
            DegatSupplementaire = Math.Max(0, degatSupp);
            Durabilite = Math.Max(1, durabilite);
        }

        public int Utiliser()
        {
            if (EstCasse)
            {
                Console.WriteLine($" L'arme {Nom} est cassée ! Aucun dégât supplémentaire.");
                return 0;
            }

            Durabilite--;
            Console.WriteLine($" {Nom} utilisée durabilité restante : {Durabilite}");

            if (EstCasse)
                Console.WriteLine($" L'arme {Nom} vient de se briser !");

            return DegatSupplementaire;
        }

        public override string ToString() => $"{Nom} + {DegatSupplementaire} dommage, durabilité {Durabilite}";

    }
}