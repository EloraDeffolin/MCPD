using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandes
{
    public class Commande
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Total { get; set; }

        public Commande(int? id, string clientid, string datecommande, decimal total)
        {
            Id = id;
            ClientId = clientid;
            DateCommande = datecommande;
            Total = total;
        }

        public override string ToString()
        {
            return $"Id : {Id}, ClientID : {ClientId}, Date de la commande : {DateCommande}, Total de la commande : {Total}.";
        }
    }
}