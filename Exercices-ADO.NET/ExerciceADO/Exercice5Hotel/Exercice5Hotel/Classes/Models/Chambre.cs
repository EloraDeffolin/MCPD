using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice4Hotel.Classes.Models;

namespace HotelManagement.Models;

public class Chambre
{
    public int Numero { get; set; }
    public StatutChambre Statut { get; set; } = StatutChambre.Libre;
    public int NbLits { get; set; }
    public decimal TarifParNuit { get; set; }

    public override string ToString()
    {
        return $"{Numero,4} | {Statut,-12} | {NbLits} lit(s) | {TarifParNuit,6:C}";
    }
}
