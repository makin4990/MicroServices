using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Guid> Create(Order order);
        IResult Update(Order order);
        IResult Delete(Guid orderId);
        IDataResult<List<Order>> GetAllOrder();
        IDataResult<List<Order>> GetOrderByCustomerId(Guid customerId);
        IDataResult<Order> GetOrderByOrderId(Guid orderId);
        IResult ChangeStatus(Guid orderId, string status);
        IDataResult<List<Order>> GetAllOrderWitDetail();
        IDataResult<List<Order>> GetAllOrderByCustomerIdWithDetail(Guid customerId);
        IDataResult<Order> GetOrderByOrderIdwithDetail(Guid orderId);

    }
}

