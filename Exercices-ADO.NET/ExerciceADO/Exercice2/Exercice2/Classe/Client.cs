using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    public class ClientInfo
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }

        public ClientInfo(int? id, string nom, string prenom, string adresse, string codepostal, string ville, string telephone)
        {
            Id = id;
            Non = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codepostal;
            Ville = ville;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Nom : {Nom}, Prenom : {Prenom}, Adresse : {Adresse} {CodePostal} {Ville}, Telephone : {Telephone}.";
        }
    }
}