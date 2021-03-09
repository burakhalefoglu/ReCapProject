using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAllCar();
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        void AddCar(Car car);
        Car GetById(int id);
    }
}
