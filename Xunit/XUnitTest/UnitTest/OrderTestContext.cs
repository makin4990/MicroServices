using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTest
{


    public class OrderTestContext:DbContext
    {

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("deneme");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.Product);
            modelBuilder.Entity<Order>().HasOne(o => o.Address);
            seedData<Order>(modelBuilder, "../../../TestData/OrderForTestData.json");
        }

        private void seedData<T>(ModelBuilder modelBuilder, string file) where T : class
        {
            using (StreamReader reader = new StreamReader(file))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T[]>(json);
                modelBuilder.Entity<T>().HasData(data);
            }

        }

        DbSet<Order> Orders { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
