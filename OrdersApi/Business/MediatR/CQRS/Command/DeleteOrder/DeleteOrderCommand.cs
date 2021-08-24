using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.MediatR.CQRS.Command.DeleteOrder
{
    public class DeleteOrderCommand:IRequest<IResult>
    {
        public Guid OrderId { get; set; }
    }
}
