﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        public Guid Id { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}
