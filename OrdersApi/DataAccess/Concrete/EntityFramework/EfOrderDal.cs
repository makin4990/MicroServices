using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfOrderDal:EfEntityRepositoryBase<Order,TesodevVtContext>,IOrderDal
    {
        

        
        public Order GetOrderdwithDetail(Expression<Func<Order, bool>> filter = null)
        {
            using (TesodevVtContext dbContext = new TesodevVtContext())
            {
                var result = dbContext.Orders
                    .Include(o => o.Address)
                    .Include(o => o.Product);

                return filter == null ? result.SingleOrDefault() : result.Where(filter).SingleOrDefault();
            }   
        }

        public List<Order> GetAllOrderWitDetail(Expression<Func<Order, bool>> filter = null)
        {
            using (TesodevVtContext dbContext = new TesodevVtContext())
            {
                var result = dbContext.Orders
                        .Include(o => o.Address)
                        .Include(o => o.Product);

                return filter == null ? result.ToList(): result.Where(filter).ToList();
            }
        }
    }
}
