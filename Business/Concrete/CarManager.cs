using Business.Abstract;
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

        public void AddCar(Car car)
        {
            if(car.Description.Length<3 || car.DailyPrice<=0)
            {
                Console.WriteLine("Validasyon hasatıs.. Eklenemedi...");
                return;
            }

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


        public List<Car> GetCarsByColorId(int id)
        {
            return carDal.GetAll(p=> p.ColorId == id);
        }
        public List<Car> GetCarsByBrandId(int id)
        {
            return carDal.GetAll(p => p.ColorId == id);
        }

        public Car GetById(int id)
        {
            return carDal.Get(p=> p.Id == id);
        }

        public void UpdateCar(Car car)
        {
            carDal.Update(car);
        }

        public List<CarDetailDto> carDetailDtos()
        {
           return carDal.carDetailDtos();
        }
    }
}
