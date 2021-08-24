using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.MediatR.CQRS.Query.GetOrderByOrderId
{
    public class GetOrderByOrderIdQuery:IRequest<IDataResult<Order>>
    {
        public Guid OrderId { get; set; }
    }
}
