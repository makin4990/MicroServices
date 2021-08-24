using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.MediatR.CQRS.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IResult>
    {
        IOrderService _orderService;

        public UpdateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<IResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Id = request.Id
                ,
                CustomerId = request.CustomerId
                ,
                Quantity = request.Quantity
                ,
                Price = request.Price
                ,
                Status = request.Status
                ,
                Address = request.Address
                ,
                Product = request.Product
                ,
                CreatedAt = request.CreatedAt
                ,
                UpdatedAt = request.UpdatedAt
            };

            var result = _orderService.Update(order);
            return Task.FromResult(result);
        }
    }
}
