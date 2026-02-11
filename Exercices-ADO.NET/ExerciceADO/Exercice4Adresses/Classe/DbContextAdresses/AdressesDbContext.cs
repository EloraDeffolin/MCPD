using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionAdresses
{
    public class AdressesDbContext : DbContext
    {
        
        public DbSet<Adresse> Adresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=ef;uid=root;pwd=",
                ServerVersion.AutoDetect("server=localhost;database=ef;uid=root;pwd=")
                );
        }
    }
}