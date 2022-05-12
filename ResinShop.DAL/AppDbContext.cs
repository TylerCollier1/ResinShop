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
        public DbSet<AdvancedFeature> AdvancedFeature { get; set; }
        public DbSet<Art> Art { get; set; }
        public DbSet<ArtColor> ArtColor { get; set; }
        public DbSet<ArtMaterial> ArtMaterial { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
        }
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ArtColor>()
                .HasKey(ac => new { ac.ArtId, ac.ColorId });
            builder.Entity<ArtMaterial>()
                .HasKey(am => new { am.ArtId, am.MaterialId });
        }
    }
}
