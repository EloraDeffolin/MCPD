using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailleurScientifique
{
    public enum Discipline
    {
        Physique,
        Chimie,
        Mathematique,
        Informatique,
        Biologie
    }

    public enum TypeScientifique
    {
        Theorique,
        Experimental,
        Informatique
    }
}

namespace TravailleurScientifique
{
    public class Scientifique : Travailleur
    {
        public Discipline Discipline { get; set; }
        public TypeScientifique TypeScientifique { get; set; }

        public Scientifique(
            string nom,
            string prenom,
            string telephone,
            string email,
            string nomEntreprise,
            string adresseEntreprise,
            string telephoneProfessionnel,
            Discipline discipline,
            TypeScientifique typeScientifique)
            : base(nom, prenom, telephone, email, nomEntreprise, adresseEntreprise, telephoneProfessionnel)
        {
            Discipline = discipline;
            TypeScientifique = typeScientifique;
        }

        public override string ToString()
        {
            return base.ToString() + $"Discipline : {Discipline}" + $"Type scientifique : {TypeScientifique}";
        }
    }
}
