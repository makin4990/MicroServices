using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
