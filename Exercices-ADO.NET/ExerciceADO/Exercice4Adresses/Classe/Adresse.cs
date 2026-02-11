using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionAdresses
{
    public class Adresse
    {
        public int Id { get; set; }
        public string NumeroVoie { get; set; }
        public string Complement { get; set; }
        public string IntituleVoie { get; set; }
        public string Commune { get; set; }
        public string CodePostal { get; set; }


        public override string ToString()
        {
            string complementAff = string.IsNullOrWhiteSpace(Complement) ? "" : " " + Complement;
            return $"{NumeroVoie}{complementAff} {IntituleVoie}, {CodePostal} {Commune}";
        }
    }
}