using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.MediatR.CQRS.Query.GetAllOrders
{
   public class GetAllOrdersQuery:IRequest<IDataResult<List<Order>>>
    {
    }
}
