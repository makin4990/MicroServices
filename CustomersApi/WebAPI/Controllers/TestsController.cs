using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public List<Customer> Gettable()
        {
            using (AlplerVTContext dbContext = new AlplerVTContext())
            {
                var result = dbContext.Customers.Include(a => a.Addresses).ToList();
                return result;
            }
        }
    }
}
