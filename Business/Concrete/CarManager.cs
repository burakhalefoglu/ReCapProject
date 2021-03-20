using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Loging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        [CacheRemoveAspect("ICarService.Get")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [AuthorizationAspect("Admin,AddCar")]
        [LogAspect(typeof(FileLogger))]
        public IResult AddCar(Car car)
        {
           

            carDal.Add(car);
            return new SuccessResult(Messages.DefaultSuccess);

        }

        [AuthorizationAspect("Admin,DeleteCar")]
        [LogAspect(typeof(FileLogger))]
        public IResult DeleteCar(Car car)
        {
            carDal.Delete(car);
            return new SuccessResult(Messages.DefaultSuccess);

        }

        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(FileLogger))]

        public IDataResult<List<Car>> GetAllCar()
        {
            Thread.Sleep(6000);

            var result = carDal.GetAll();

            return new SuccessDataResult<List<Car>>(result,Messages.DefaultSuccess);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = carDal.GetAll(p=> p.ColorId == id);
            return new SuccessDataResult<List<Car>>(result);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = carDal.GetAll(p => p.ColorId == id);
            return new SuccessDataResult<List<Car>>(result, Messages.DefaultSuccess);

        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var result= carDal.Get(p=> p.Id == id);
            return new SuccessDataResult<Car>(result,Messages.DefaultSuccess);

        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [LogAspect(typeof(FileLogger))]

        public IResult UpdateCar(Car car)
        {
            carDal.Update(car);
            return new SuccessResult(Messages.DefaultSuccess);

        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> carDetailDtos()
        {
           var result = carDal.carDetailDtos();
            return new SuccessDataResult<List<CarDetailDto>>(result);

        }
    }
}
