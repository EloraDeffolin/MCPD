using System;
using System;


namespace CPOO.Classes
{
    internal abstract class Personnage
    {
        public string Nom { get; protected set; }
        public string Prenom { get; protected set; }
        public int PV { get; protected set; }
        public int PVMax { get; protected set; }
        public int Damage { get; protected set; }
        public Arme ArmeEquipee { get; protected set; }

        protected Personnage(string nom, string prenom, int pv, int damage, Arme arme = null)
        {
            Nom = nom ?? "Inconnu";
            Prenom = prenom ?? "";
            PV = pv;
            PVMax = pv;
            Damage = damage;
            ArmeEquipee = arme;
        }

        public abstract void Attaquer(Personnage cible);

        public virtual void SubirDegats(int degats)
        {
            PV = Math.Max(0, PV - degats);
            Console.WriteLine($" {Prenom} {Nom} perd {degats} PV {PV}/{PVMax} PV restants");
        }

        public bool EstVivant => PV > 0;

        public override string ToString()
        {
            string armeInfo = ArmeEquipee != null
                ? $"{ArmeEquipee.Nom} (dégâts + {ArmeEquipee.DegatSupplementaire}, durabilité {ArmeEquipee.Durabilite})"
                : "Aucune arme";

            return $"{GetType().Name,-12} {Prenom} {Nom,-18} | PV: {PV,3}/{PVMax,-3} | Base dmg: {Damage,-2} | {armeInfo}";
        }
    }
}