using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAllCustomer();
        IResult UpdateCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult AddCustomer(Customer customer);
    }
}
