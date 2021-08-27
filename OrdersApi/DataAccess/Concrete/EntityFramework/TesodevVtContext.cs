using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
      public class TesodevVtContext : DbContext
    {
        public TesodevVtContext()
        {

        }
        public TesodevVtContext(DbContextOptions<TesodevVtContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=BILGISLEM;Database=TesodevDB;Trusted_Connection=true");
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>()
            //    .HasMany(c => c.Addresses)
            //    .WithOne(c => c.Customer)
            //    .HasForeignKey(c => c.CustomerId);
           // modelBuilder.Entity<Address>(builder => builder.HasNoKey());

        }

       
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}