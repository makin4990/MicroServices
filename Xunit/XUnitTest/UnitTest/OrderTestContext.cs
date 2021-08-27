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
    public class OrderTestContext: TesodevVtContext
    {
        public OrderTestContext(DbContextOptions<TesodevVtContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.Product);
            modelBuilder.Entity<Order>().HasOne(o => o.Address);
            base.OnModelCreating(modelBuilder);
            seedData<Address>(modelBuilder, "../../../TestData/AddressForTestData.json");
            seedData<Product>(modelBuilder, "../../../TestData/ProductForTestData.json");
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
    }
}
