using Entities.Concrete;
using Newtonsoft.Json;
using OrderAPI;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace UnitTest
{
    public class OrdersControllerTest : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private InMemoryWebApplicationFactory<Startup> factory;

        public OrdersControllerTest(InMemoryWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }
        [Fact]
        public async Task web_api_basari_testi()
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync("/api/orders/getallorders");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task post_request_test()
        {
            Address newAddress = new Address
            {
                AddressLine = "Aydın Organize Sanayi Bölgesi Umurlu/Efeler"
                ,
                Id = Guid.NewGuid()
                ,
                City = "Aydın"
                ,
                Country = "Turkey"
                ,
                CityCode = 9100
                ,
                CustomerId = new Guid("6c89b0db-8901-ec11-ad1c-204ef6a9b4ee")
            };
            Product newProduct = new Product
            {
                Id = new Guid("010e9eff-b401-ec11-ad1c-204ef6a9b4ee"),
                ImageUrl = "/env/img",
                Name = "product1"

            };
            var order = new Order
            {
                Id = Guid.NewGuid()
               , CustomerId = new Guid("6c89b0db-8901-ec11-ad1c-204ef6a9b4ee")
               , Quantity = 249
               , Price = 999
               , Status = "Waiting for shipping"
               ,Address = newAddress
               ,Product=newProduct
               ,CreatedAt = new DateTime(2021,8,24)
               ,UpdatedAt = new DateTime(2021, 8, 24)

            };
             
            var client = factory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/orders/create", httpContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);

        }
        [Fact]
        public async Task put_request_test()
        {
            var client = factory.CreateClient();
            var request = new Order
            {
                Id = new Guid("218a8ca6-eb62-474f-8858-955bd7b8ea7e")
               ,
                CustomerId = new Guid("6c89b0db-8901-ec11-ad1c-204ef6a9b4ee")
               ,
                Quantity = 249
               ,
                Price = 999
               ,
                Status = "Waiting for shipping"
               ,
                CreatedAt = new DateTime(2021, 8, 24)
               ,
                UpdatedAt = new DateTime(2021, 8, 24)

            };
            //request.Address = new Address
            //{
            //    AddressLine = "Aydın Organize Sanayi Bölgesi Umurlu/Efeler"
            //    ,
            //    Id = Guid.NewGuid()
            //    ,
            //    City = "Aydın"
            //    ,
            //    Country = "Turkey"
            //    ,
            //    CityCode = 9100
            //    ,
            //    CustomerId = new Guid("6c89b0db-8901-ec11-ad1c-204ef6a9b4ee")
            //};
            //request.Product = new Product
            //{
            //    Id = new Guid("010e9eff-b401-ec11-ad1c-204ef6a9b4ee"),
            //    ImageUrl = "/env/img",
            //    Name = "product1"

            //};
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            //Assert.NotNull(headerLocation.PathAndQuery);
            var response = await client.PutAsync("api/orders/update", httpContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task get_by_id_request_test()
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync("/api/orders/getbyorderid?orderid=48451c21-b501-ec11-ad1c-204ef6a9b4ee");
            var strinResult = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<Order>(strinResult);
            Assert.Equal("3900", jsonObject.Price.ToString());
        }
    }
}
