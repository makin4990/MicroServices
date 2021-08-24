using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, AlplerVTContext>, ICustomerDal
    {
        public List<Customer> GetAllCustomerWithAddress()
        {
            using (AlplerVTContext dbContext = new AlplerVTContext())
            {
                var result = dbContext.Customers.Include(a => a.Addresses).ToList();
                return result;
            }
        }

        public Customer GetCustomerByIdWithAddress(Guid customerId)
        {
            using (AlplerVTContext dbContext = new AlplerVTContext())
            {
                return dbContext.Customers.Include(a => a.Addresses).Where(a => a.Id == customerId).FirstOrDefault();
            }
        }
    }
}
