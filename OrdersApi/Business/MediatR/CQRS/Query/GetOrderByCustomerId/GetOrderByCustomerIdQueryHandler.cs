using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.MediatR.CQRS.Query.GetOrderByCustomerId
{
    public class GetOrderByCustomerIdQueryHandler : IRequestHandler<GetOrderByCustomerIdQuery, IDataResult<Order>>
    {
        IOrderService _orderService;

        public GetOrderByCustomerIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<IDataResult<Order>> Handle(GetOrderByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var result = _orderService.GetOrderByOrderIdwithDetail(request.CustomerId);
            return Task.FromResult(result);
            

        }
    }
}
