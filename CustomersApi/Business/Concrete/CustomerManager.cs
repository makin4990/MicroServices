using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<Guid> Create(Customer customer)
        {
           
            _customerDal.Add(customer);
            return new SuccessDataResult<Guid>(customer.Id, Messages.CustomerAdded);

        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
         public IResult Delete(Guid id)
        {
            Customer customer = new Customer { Id = id };
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
        public IDataResult<List<Customer>> GetAll()
        {
           
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }
        public IDataResult<Customer> GetById(Guid id)
        {
            
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.CustomerListed);
        }
        
        public IResult Validate(Guid id)
        {
            var result = _customerDal.GetAll(c => c.Id == id).Any();


            return result ? new SuccessResult(Messages.Validated) : new ErrorResult(Messages.NotValidated);
            
            
        }

        public IDataResult<List<Customer>> GetAllCustomerWithAddress()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAllCustomerWithAddress(),Messages.CustomerListed);
        }
        public IDataResult<Customer> GetCustomerByIdWithAddress(Guid customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetCustomerByIdWithAddress(customerId), Messages.CustomerListed);
        }

       
    }
}
