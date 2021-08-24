using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        List<Order> GetAllOrderWitDetail(Expression<Func<Order, bool>> filter = null);
        Order GetOrderdwithDetail(Expression<Func<Order, bool>> filter = null);


    }
}
