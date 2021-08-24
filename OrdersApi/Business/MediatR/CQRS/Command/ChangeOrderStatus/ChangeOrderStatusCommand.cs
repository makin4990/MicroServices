using Entities.Concrete;
using MediatR;
using System;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Text;

namespace Business.MediatR.CQRS.Command.ChangeOrderStatus
{
    public class ChangeOrderStatusCommand:IRequest<IResult>
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
    }
}
