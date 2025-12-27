
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class OtoMuhasebeContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles{ get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=OtoMuhasebe.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasOne(x => x.Customer)
                .WithMany(m=> m.Vehicles)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasOne(a=> a.Vehicle)
                .WithMany(m=> m.Services)
                .HasForeignKey(a => a.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
