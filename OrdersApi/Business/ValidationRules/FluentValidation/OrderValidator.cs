using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.Quantity).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Status).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.Product).NotEmpty();
            RuleFor(c => c.CreatedAt).NotEmpty();
            RuleFor(c => c.UpdatedAt).NotEmpty();

        }
    }
}
