using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravailleurScientifique
{
    public class Travailleur : Personne
    {
        public string NomEntreprise { get; set; }
        public string AdresseEntreprise { get; set; }
        public string TelephoneProfessionnel { get; set; }

        public Travailleur(string nom, string prenom, string telephone, string email, string nomEntreprise, string adresseEntreprise, string telephoneProfessionnel)
        : base(nom, prenom, telephone, email)
        {
            NomEntreprise = nomEntreprise;
            AdresseEntreprise = adresseEntreprise;
            TelephoneProfessionnel = telephoneProfessionnel;
        }

        public override string ToString()
        {
            return base.ToString() + $"Entreprise : {NomEntreprise}" + $"Adresse entreprise : {AdresseEntreprise}" + $"Téléphone pro : {TelephoneProfessionnel}";
        }
    }
}
