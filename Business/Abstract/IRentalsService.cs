using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAllRentals();
        IResult UpdateRental(Rentals rental);
        IResult DeleteRental(Rentals car);
        IResult AddRental(Rentals rental);
        IDataResult<Rentals> GetById(int id);
    }
}
