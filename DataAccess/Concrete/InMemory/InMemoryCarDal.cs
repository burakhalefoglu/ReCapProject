using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;

        public InMemoryCarDal()
        {
            cars = new List<Car> {

                new Car{ Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500000, Description = "volvo", ModelYear = 2016 },
                new Car{ Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 200000, Description = "mercedes", ModelYear = 2018 },
                new Car{ Id = 3, BrandId = 3, ColorId = 2, DailyPrice = 300000, Description = "opel", ModelYear = 2020 },
                new Car{ Id = 4, BrandId = 1, ColorId = 3, DailyPrice = 200000, Description = "volvo", ModelYear = 2019 },
                new Car{ Id = 5, BrandId = 4, ColorId = 1, DailyPrice = 100000, Description = "honda", ModelYear = 2009 }

            };
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public List<CarDetailDto> carDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            var selectedCar = cars.SingleOrDefault(car => car.Id == car.Id);
            if (selectedCar != null)
            {
                cars.Remove(selectedCar);
            }
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
            
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var selectedCar = cars.SingleOrDefault(car => car.Id == car.Id);
            if (selectedCar != null)
            {
                selectedCar.BrandId = car.BrandId;
                selectedCar.ColorId = car.ColorId;
                selectedCar.DailyPrice = car.DailyPrice;
                selectedCar.Description = car.Description;
                selectedCar.ModelYear = car.ModelYear;
            }
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
