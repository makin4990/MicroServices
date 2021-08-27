using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public Order()
        {
            Address = new Address();
            Product = new Product();

        }
        /* Merhabalar OrderItem adında bir entity oluşturup 
         * quantiy, ... ve price properyty'lerini orada tutmayı düşündüm 
         * ancak verilen case'in çok dışına çıkmak zorunda kalacağım için bu şekilde devam ettim*/

        public  Guid  Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public virtual Address Address { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Guid AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        

    }
}
