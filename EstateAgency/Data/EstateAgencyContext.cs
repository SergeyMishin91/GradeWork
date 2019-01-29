using EstateAgency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Data
{
    public class EstateAgencyContext: DbContext
    {
        public EstateAgencyContext(DbContextOptions<EstateAgencyContext> options)
            :base(options)
        {
        }

        #region DbSets
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Firm> Firms { get; set; }

        public DbSet<Estate> Estates { get; set; }
        public DbSet<RentEstate> RentEstates { get; set; }
        public DbSet<SaleEstate> SaleEstates { get; set; }

        public DbSet<Client_Treaty> Client_Treaties { get; set; }
        public DbSet<RentEstate_Lease> RentEstate_Leases { get; set; }

        public DbSet<Treaty> Treaties { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<SaleTreaty> SaleTreaties { get; set; }

        public DbSet<Application> Applications { get; set; }
        public DbSet<SaleApplication> SaleApplications { get; set; }
        public DbSet<RentApplication> RentApplications { get; set; }
        #endregion

        #region ModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Firm>().ToTable("Firm");

            modelBuilder.Entity<Estate>().ToTable("Estate");
            modelBuilder.Entity<RentEstate>().ToTable("RentEstate");
            modelBuilder.Entity<SaleEstate>().ToTable("SaleEstate");

            modelBuilder.Entity<Client_Treaty>().ToTable("Client_Treaty");
            modelBuilder.Entity<RentEstate_Lease>().ToTable("RentEstate_Lease");

            modelBuilder.Entity<Treaty>().ToTable("Treaty");
            modelBuilder.Entity<Lease>().ToTable("Lease");
            modelBuilder.Entity<SaleTreaty>().ToTable("SaleTreaty");

            modelBuilder.Entity<Client_Treaty>()
                .HasKey(c => new { c.ClientID, c.TreatyID });

            modelBuilder.Entity<RentEstate_Lease>()
                .HasKey(r => new { r.EstateID, r.LeaseID});

            modelBuilder.Entity<Application>().ToTable("Application");
            modelBuilder.Entity<SaleApplication>().ToTable("SaleApplication");
            modelBuilder.Entity<RentApplication>().ToTable("RentApplication");
        }
        #endregion

    }
}
