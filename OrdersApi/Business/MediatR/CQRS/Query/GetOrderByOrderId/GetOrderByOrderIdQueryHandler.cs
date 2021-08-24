using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.MediatR.CQRS.Query.GetOrderByOrderId
{
    public class GetOrderByOrderIdQueryHandler : IRequestHandler<GetOrderByOrderIdQuery, IDataResult<Order>>
    {
        IOrderService _orderService;

        public GetOrderByOrderIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<IDataResult<Order>> Handle(GetOrderByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var result = _orderService.GetOrderByOrderIdwithDetail(request.OrderId);
            return Task.FromResult(result);
        }
    }
}
