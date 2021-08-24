using Business.Abstract;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.MediatR.CQRS.Command.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand,IResult>
    {
        IOrderService _orderService;

        public ChangeOrderStatusCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<IResult> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var result = _orderService.ChangeStatus(request.OrderId, request.Status);
            return Task.FromResult(result);
        }
    }
}
