using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.FakeDAL
{
    public class OrderManagerFake : IOrderServiceFake
    {
        IOrderDalFake _orderDalFake;

        public OrderManagerFake(IOrderDalFake orderDalFake)
        {
            _orderDalFake = orderDalFake;
        }

        public IResult ChangeStatus(Guid orderId, string status)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Guid> Create(Order order)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAllOrderByCustomerIdWithDetail(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAllOrderWitDetail()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetOrderByCustomerId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order> GetOrderByOrderId(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order> GetOrderByOrderIdwithDetail(Guid orderId)
        {
            return new SuccessDataResult<Order>(_orderDalFake.GetOrderdwithDetail(o => o.Id == orderId));
        }

        public IResult Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
