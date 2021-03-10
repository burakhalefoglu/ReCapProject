using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.carDetailDtos())
            {
                Console.WriteLine(car.BrandName + "-_-" +car.ColorName);
            }
            

        }
    }
}
