using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.MediatR.CQRS.Query.GetOrderByCustomerId
{
    public class GetOrderByCustomerIdQuery:IRequest<IDataResult<Order>>
    {
        public Guid CustomerId { get; set; }
    }
}
