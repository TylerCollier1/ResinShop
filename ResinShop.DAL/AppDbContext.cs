using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ResinShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ResinShop.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<AdvancedFeature> AdvancedFeatures { get; set; }
        public DbSet<Art> Arts { get; set; }
        public DbSet<ArtColor> ArtColors { get; set; }
        public DbSet<ArtMaterial> ArtMaterials { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
        }
        public ApplicationDbContext() : base()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
