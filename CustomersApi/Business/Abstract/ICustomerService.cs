using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetAllCustomerWithAddress();
        IDataResult<Customer> GetCustomerByIdWithAddress(Guid customerId);
        IDataResult<Customer> GetById(Guid customerId);
        IDataResult<Guid> Create(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Guid customerId);
        IResult Validate(Guid customerId);
    }
}
