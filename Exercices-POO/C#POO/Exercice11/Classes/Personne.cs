using System;

namespace TravailleurScientifique
{
    public abstract class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        protected Personne(string nom, string prenom, string telephone, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Email = email;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}, Email : {Email}";
        }
    }
}
