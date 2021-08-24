using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.MediatR.CQRS.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IDataResult<Guid>>
    {
        IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<IDataResult<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order() { Id = Guid.NewGuid()
                , CustomerId = request.CustomerId
                , Quantity = request.Quantity
                , Price = request.Price
                , Status = request.Status
                , Address = request.Address
                , Product = request.Product
                , CreatedAt= request.CreatedAt
                , UpdatedAt= request.UpdatedAt
            };
            var result = _orderService.Create(order);
            return Task.FromResult(result);
        }
    }
}
