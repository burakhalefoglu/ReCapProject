using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult AddRental(Rental rental)
        {
            rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult DeleteRental(Rental rental)
        {
            rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            var result = rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = rentalDal.Get(r=> r.CustomerId ==id);
            return new SuccessDataResult<Rental>(result);
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult UpdateRental(Rental rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
