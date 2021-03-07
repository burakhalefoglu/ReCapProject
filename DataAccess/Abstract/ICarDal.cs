using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetById(int id);
        void Update(Car car);
        void Add(Car car);
        void Delete(Car car);

    }
}
