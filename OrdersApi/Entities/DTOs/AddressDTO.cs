using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AddressDTO:IDto
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }

    }
}
