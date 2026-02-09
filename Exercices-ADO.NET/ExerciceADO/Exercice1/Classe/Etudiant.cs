using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiantsAdoNet
{
    public class Etudiant
    {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }

        public Personne(int? id, string nom, string prenom, int datenaissance, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = datenaissance;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Id,4} | {Nom,-15} | {Prenom,-15} | {DateNaissance:dd/MM/yyyy} | {Email}";
        }
    }
}