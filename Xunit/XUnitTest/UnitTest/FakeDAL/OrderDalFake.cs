using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UnitTest.FakeDAL
{
    public class OrderDalFake : IOrderDalFake
    {

        List<Order> _orders;

        public OrderDalFake()
        {
            _orders = new List<Order>();
            SeedData(@"../../../TestData/OrderForTestData.json");
        }

        private void SeedData(string file) 
        {
            _orders.Add(new Order
            {
                Id = Guid.Parse("48451c21-b501-ec11-ad1c-204ef6a9b4ee"),
                CreatedAt = DateTime.Now,
                Price = 3900,
                Quantity = 9,
                CustomerId = Guid.Parse("d4382973-b805-4b63-ab19-c2b369565667"),
                Status = "Status2",
                UpdatedAt = DateTime.Now,
            });
            
        }

        public Order Add(Order entity)
        {
            _orders.Add(entity);
            return entity;
        }

        public void Delete(Order entity)
        {
            _orders.Remove(entity);
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            return _orders.AsQueryable().Where(filter).FirstOrDefault();
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            return _orders;
        }

        public List<Order> GetAllOrderWitDetail(Expression<Func<Order, bool>> filter = null)
        {
            return _orders.AsQueryable().Where(filter).ToList();
        }

        public Order GetOrderdwithDetail(Expression<Func<Order, bool>> filter = null)
        {
            return _orders.AsQueryable().Where(filter).FirstOrDefault();
        }

        public Order Update(Order entity)
        {
            Order order = _orders.Find(p => p.Id == entity.Id);
            order = entity;
            return order;
        }
    }
}
