using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.MediatR.CQRS.Command.CreateOrder
{
   public class CreateOrderCommand:IRequest<IDataResult<Guid>>
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public virtual Address Address { get; set; }
        public virtual Product Product { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
