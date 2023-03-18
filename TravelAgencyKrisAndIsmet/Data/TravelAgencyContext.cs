
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
        public DbSet<Bus> Buses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Travel> Travels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = DESKTOP-E42ENN9\SQLEXPRESS; Database = TravelAgency; Integrated security = true");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
