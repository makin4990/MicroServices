using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Addresses).NotEmpty();
            RuleFor(c => c.UpdatedAt).NotEmpty();
            RuleFor(c => c.CreatedAt).NotEmpty();
        }
    }
}
