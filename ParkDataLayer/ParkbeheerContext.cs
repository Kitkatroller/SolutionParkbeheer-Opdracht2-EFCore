using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer
{
    public class ParkbeheerContext : DbContext
    {
        public DbSet<ParkEF> Parks { get; set; }
        public DbSet<HuisEF> Huizen { get; set; }
        public DbSet<HuurderEF> Huurders { get; set; }
        public DbSet<HuurcontractEF> Huurcontracten { get; set; }
        public DbSet<HuurperiodeEF> Huurperiodes { get; set; }
        public DbSet<ContactgegevensEF> Contactgegevens { get; set; }

        public ParkbeheerContext(string connectionString) : base(new DbContextOptionsBuilder<ParkbeheerContext>()
           .UseSqlServer(connectionString)
           .Options)
        {          
        }

        public ParkbeheerContext(DbContextOptions<ParkbeheerContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<ParkEF>()
                .HasMany(p => p.Huizen)
                .WithOne(h => h.Park)
                .HasForeignKey(h => h.ParkId);

            modelBuilder.Entity<HuurderEF>()
                .HasOne(hd => hd.Contactgegevens)
                .WithOne(cg => cg.Huurder)
                .HasForeignKey<ContactgegevensEF>(cg => cg.Huurder_Id);

            modelBuilder.Entity<HuisEF>()
                .HasMany(h => h.Huurcontracten)
                .WithOne(hc => hc.Huis)
                .HasForeignKey(hc => hc.Huis_Id);

            modelBuilder.Entity<HuurderEF>()
                .HasMany(hd => hd.Huurcontracten)
                .WithOne(hc => hc.Huurder)
                .HasForeignKey(hc => hc.Huurder_Id);

            modelBuilder.Entity<HuurcontractEF>()
                .HasOne(hc => hc.Huurperiode)
                .WithOne(hp => hp.Huurcontract)
                .HasForeignKey<HuurperiodeEF>(hp => hp.Huurcontract_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
