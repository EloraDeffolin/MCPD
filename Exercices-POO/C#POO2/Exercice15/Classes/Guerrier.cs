using System;
using static System.Net.Mime.MediaTypeNames;


namespace CPOO.Classes
{
    internal class Guerrier : Personange, IAttaqueSpeciale
    {
        public Guerrier(string nom, string prenom, int pv, int damage, Arme arme)
        : base(nom, prenom, pv, damage, arme)
        {
        }

        public override void Attaquer(Personnage cible)
        {
            if (!EstVivant || !cible.EstVivant) return;

            Console.WriteLine($"\n{Guerrier} {Prenom} {Nom} attaque {cible.Prenom} {cible.Nom} avec une attaque normale");

            int degats = Damage;
            if (ArmeEquipee != null)
                degats += ArmeEquipee.Utiliser();

            cible.SubirDegats(degats);
        }

        public void AttaqueSpeciale(Personnage cible)
        {
            if (!EstVivant || !cible.EstVivant) return;

            Console.WriteLine($"\n{Prenom} {Nom} utilise son **Coup Puissant** !");

            int degats = Damage * 2;
            if (ArmeEquipee != null)
                degats += ArmeEquipee.Utiliser() * 2;

            cible.SubirDegats(degats);
        }

    }
}