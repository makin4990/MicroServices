using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.MediatR.CQRS.Query.GetAllOrders
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrdersQuery, IDataResult<List<Order>>>
    {
        IOrderService _orderService;
         public GetAllOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<IDataResult<List<Order>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = _orderService.GetAllOrderWitDetail();
            return Task.FromResult(result);
        }
    }

}
