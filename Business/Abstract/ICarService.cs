using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAllCar();
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);
        IResult AddCar(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> carDetailDtos();
    }
}
