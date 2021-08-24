using Business.Abstract;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.MediatR.CQRS.Command.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, IResult>
    {
        IOrderService _orderService;

        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<IResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result =_orderService.Delete(request.OrderId);
            return Task.FromResult(result);
        }
    }
}
