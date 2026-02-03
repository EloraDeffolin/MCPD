using System;
using Exercice15.Interface;


namespace CPOO.Classes
{
    public class GuerrierMage : Personnage, IAttaqueSpeciale, IMagie
    {
        public GuerrierMage(string nom, string prenom, int pv, int damage, Arme arme)
            : base(nom, prenom, pv, damage, arme)
        {
        }

        public override void Attaquer(Personnage cible)
        {
            if (!EstVivant || !cible.EstVivant) return;

            Console.WriteLine($"\n{GuerrierMage} {Prenom} {Nom} attaque normalement");

            int degats = Damage;
            if (ArmeEquipee != null)
                degats += ArmeEquipee.Utiliser();

            cible.SubirDegats(degats);
        }

        public void AttaqueSpeciale(Personnage cible)
        {
            if (!EstVivant || !cible.EstVivant) return;

            Console.WriteLine($" {Prenom} {Nom} utilise **Frappe Runique** !");

            int degats = Damage * 2 + 8;
            if (ArmeEquipee != null)
                degats += ArmeEquipee.Utiliser() * 2;

            cible.SubirDegats(degats);
        }

        public void LancerSort(Personnage cible)
        {
            if (!EstVivant || !cible.EstVivant) return;

            Console.WriteLine($"{Prenom} {Nom} lance **Éclair Arcanique** !");

            int degats = Damage + 15;
            if (ArmeEquipee != null)
                degats += ArmeEquipee.Utiliser();

            cible.SubirDegats(degats);
        }
    }

}