using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public Customer()
        {
            Addresses = new List<Address>();
          
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
