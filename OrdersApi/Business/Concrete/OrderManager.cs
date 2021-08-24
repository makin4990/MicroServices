using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult ChangeStatus(Guid orderId, string status)
        {
            Order order = new Order { Id = orderId, Status = status };
            _orderDal.Update(order);
            return new SuccessResult(Messages.StatusChanged);
        }

        public IDataResult<Guid> Create(Order order)
        {
           _orderDal.Add(order);
            return new SuccessDataResult<Guid>(order.Id, Messages.OrderAdded);
        }

        public IResult Delete(Guid orderId)
        {
            Order order = new Order { Id = orderId };
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<List<Order>> GetAllOrder()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<List<Order>> GetAllOrderByCustomerIdWithDetail(Guid customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAllOrderWitDetail(o=> o.CustomerId==customerId));
        }

        public IDataResult<List<Order>> GetAllOrderWitDetail()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAllOrderWitDetail());
        }

        public IDataResult<List<Order>> GetOrderByCustomerId(Guid customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o=> o.CustomerId==customerId));
        }

        public IDataResult<Order> GetOrderByOrderId(Guid orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(c => c.Id == orderId));
        }

        public IDataResult<Order> GetOrderByOrderIdwithDetail(Guid orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.GetOrderdwithDetail(o => o.Id == orderId));
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }

        
    }
}

