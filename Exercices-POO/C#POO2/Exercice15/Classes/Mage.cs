using System;
using Exercice15.Interface;

namespace CPOO.Classes
{
    public class Mage : Personnage, IMagie
    {
        public Mage(string nom, string prenom, int pv, int damage, Arme arme = null)
            : base(nom, prenom, pv, damage, arme)
        {
        }

        public override void Attaquer(Personnage cible)
        {
            if (!EstVivant || !cible.EstVivant) return;

            Console.WriteLine($" {Mage} {Prenom} {Nom} lance une attaque magique de base");

            int degats = Damage;
            if (ArmeEquipee != null)
                degats += ArmeEquipee.Utiliser();

            cible.SubirDegats(degats);
        }

        public void LancerSort(Personnage cible)
        {
            if (!EstVivant || !cible.EstVivant) return;

            Console.WriteLine($"{Prenom} {Nom} lance **Boule de Feu** !");

            int degats = Damage + 12;
            if (ArmeEquipee != null)
                degats += ArmeEquipee.Utiliser();

            cible.SubirDegats(degats);
        }
    }

}