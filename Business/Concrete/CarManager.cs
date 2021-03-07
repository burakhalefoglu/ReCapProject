using Business.Abstract;
using DataAccess.Abstract;
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

        public void AddCar(Car car)
        {
            carDal.Add(car);

        }

        public void DeleteCar(Car car)
        {
            carDal.Delete(car);
        }

        public List<Car> GetAllCar()
        {
          return  carDal.GetAll();
        }

        public List<Car> GetCarById(int id)
        {
            return carDal.GetById(id);
        }

        public void UpdateCar(Car car)
        {
            carDal.Update(car);
        }
    }
}
