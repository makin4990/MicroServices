using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDTO:IDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public virtual Address Address { get; set; }
        public virtual Product Product { get; set; }
    }
}
