using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.ImageUrl).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();

        }
    }
}
