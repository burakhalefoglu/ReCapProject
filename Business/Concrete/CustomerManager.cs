using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomersDal customerDal;

        public CustomerManager(ICustomersDal customerDal)
        {
            this.customerDal = customerDal;
        }


        public IResult AddCustomer(Customer customer)
        {
            customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult DeleteCustomer(Customer customer)
        {
            customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAllCustomer()
        {
            var result = customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IResult UpdateCustomer(Customer customer)
        {
            customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
