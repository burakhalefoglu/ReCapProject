using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
 
    public class CarManager : ICarService
    {
        ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
           

            carDal.Add(car);
            return new SuccessResult(Messages.DefaultSuccess);

        }

        public IResult DeleteCar(Car car)
        {
            carDal.Delete(car);
            return new SuccessResult(Messages.DefaultSuccess);

        }

        public IDataResult<List<Car>> GetAllCar()
        {
            var result = carDal.GetAll();

            return new SuccessDataResult<List<Car>>(result,Messages.DefaultSuccess);
        }


        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = carDal.GetAll(p=> p.ColorId == id);
            return new SuccessDataResult<List<Car>>(result);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = carDal.GetAll(p => p.ColorId == id);
            return new SuccessDataResult<List<Car>>(result, Messages.DefaultSuccess);

        }

        public IDataResult<Car> GetById(int id)
        {
            var result= carDal.Get(p=> p.Id == id);
            return new SuccessDataResult<Car>(result,Messages.DefaultSuccess);

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
            carDal.Update(car);
            return new SuccessResult(Messages.DefaultSuccess);

        }

        public IDataResult<List<CarDetailDto>> carDetailDtos()
        {
           var result = carDal.carDetailDtos();
            return new SuccessDataResult<List<CarDetailDto>>(result);

        }
    }
}
