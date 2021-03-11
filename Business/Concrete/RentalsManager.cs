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
    public class RentalsManager : IRentalsService
    {
        IRentalsDal rentalDal;

        public RentalsManager(IRentalsDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        public IResult AddRental(Rentals rental)
        {
            rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult DeleteRental(Rentals rental)
        {
            rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rentals>> GetAllRentals()
        {
            var result = rentalDal.GetAll();
            return new SuccessDataResult<List<Rentals>>(result);
        }

        public IDataResult<Rentals> GetById(int id)
        {
            var result = rentalDal.Get(r=> r.CustomerId ==id);
            return new SuccessDataResult<Rentals>(result);
        }

        public IResult UpdateRental(Rentals rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
