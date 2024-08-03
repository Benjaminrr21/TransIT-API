
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Models;
using TransIT.Domain.Models.Users;

namespace TransIT.Infrastructure
{
    public class TransITContext : DbContext
    {
        public TransITContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TravelCost> TravelCosts { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<PricesList> PricesList { get; set; }
        public DbSet<Employee> Employees { get; set; }


        
    }
}
