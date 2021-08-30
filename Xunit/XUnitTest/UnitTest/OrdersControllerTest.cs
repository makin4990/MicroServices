using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using OrderAPI;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnitTest.FakeDAL;
using Xunit;


namespace UnitTest
{
    public class OrdersControllerTest : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private InMemoryWebApplicationFactory<Startup> factory;

       

        IOrderService _service;
        IOrderDalFake _orderDalFake;
        public OrdersControllerTest()
        {
            _orderDalFake = new OrderDalFake();
            _service = new OrderManager(_orderDalFake);
        }

       
        [Fact]
        public async Task get_by_id_request_test()
        {

            var result= _service.GetOrderByOrderIdwithDetail(Guid.Parse("48451c21-b501-ec11-ad1c-204ef6a9b4ee"));
            Order order =  result.Data;
            Assert.Equal(3900, order.Price);
        }
    }
}
