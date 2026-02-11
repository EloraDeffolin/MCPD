using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice4Hotel.Classes.Models;

namespace HotelManagement.Models;

public class Reservation
{
    public int Id { get; set; }
    public StatutReservation Statut { get; set; } = StatutReservation.Prevu;
    public Chambre? Chambre { get; set; }
    public Client? Client { get; set; }
    public DateTime DateArrivee { get; set; }
    public DateTime DateDepart { get; set; }

    public override string ToString()
    {
        return $"{Id,4} | {Statut,-10} | Chambre {Chambre?.Numero} | {Client?.NomComplet,-25} | {DateArrivee:dd/MM} → {DateDepart:dd/MM}";
    }
}
