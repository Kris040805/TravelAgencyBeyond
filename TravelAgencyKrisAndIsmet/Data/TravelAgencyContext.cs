
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class TravelAgencyContext : DbContext
    {
        public virtual DbSet<Bus> Buses { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<Travel> Travels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //DESKTOP-J4IDPFS\SQLEXPRESS na ismet
                //DESKTOP-E42ENN9\SQLEXPRESS na kris
                optionsBuilder.UseSqlServer(@"Server = DESKTOP-E42ENN9\SQLEXPRESS; Database = TravelAgency; Integrated security = true");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
