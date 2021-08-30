using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace UnitTest
{
    public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                   .ConfigureTestServices(services =>
                   {
                       var options = new DbContextOptionsBuilder<TesodevVtContext>()
                                                              .UseInMemoryDatabase("testMemory").Options;
                       //services.AddScoped<TesodevVtContext>(provider => new OrderTestContext(options));

                       var serviceProvider = services.BuildServiceProvider();
                       using var scope = serviceProvider.CreateScope();
                       var scopedService = scope.ServiceProvider;
                       var db = scopedService.GetRequiredService<TesodevVtContext>();
                       db.Database.EnsureCreated();

                   });
        }
    }
}
