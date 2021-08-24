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
            base.OnModelCreating(modelBuilder);
            seedData<Order>(modelBuilder, "../../../TestData/TestData.json");
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
