using Framework.Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeService.Entities
{
    public class CoffeeDBContext:BaseContext
    {
        private readonly string connectionString;

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<CoffeeType> CoffeeTypes { get; set; }
        public DbSet<CoffeeStore> CoffeeStores { get; set; }

        public CoffeeDBContext()
        {
            connectionString = GlobalInformation.ConnectionString;
        }
        public CoffeeDBContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("CoffeeDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
