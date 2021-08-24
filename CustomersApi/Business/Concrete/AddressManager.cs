using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager:IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        [ValidationAspect(typeof(Address))]
        public IResult Create(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(Messages.CustomerAdded);

        }

        [ValidationAspect(typeof(Address))]
        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        public IResult Delete(Guid customerId)
        {
            Address address = new Address { CustomerId = customerId };
            _addressDal.Delete(address);
            return new SuccessResult(Messages.CustomerDeleted);
        }
        public IDataResult<List<Address>> Get()
        {
            _addressDal.GetAll();
            return new SuccessDataResult<List<Address>>(Messages.CustomerListed);
        }
        public IDataResult<Address> GetById(Guid customerId)
        {
            _addressDal.Get(c => c.CustomerId == customerId);
            return new SuccessDataResult<Address>(Messages.CustomerListed);
        }
    }
}
