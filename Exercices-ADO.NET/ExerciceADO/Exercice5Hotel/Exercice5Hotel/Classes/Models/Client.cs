using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models;

public class Client
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;

    public string NomComplet => $"{Prenom} {Nom}".Trim();

    public override string ToString()
    {
        return $"{Id,3} | {NomComplet,-30} | {Telephone}";
    }
}