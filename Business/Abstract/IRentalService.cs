using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAllRentals();
        IResult UpdateRental(Rental rental);
        IResult DeleteRental(Rental car);
        IResult AddRental(Rental rental);
        IDataResult<Rental> GetById(int id);
    }
}
