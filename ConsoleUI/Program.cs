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
            VisualCarData();
          
        }



        private static void VisualCarData()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.carDetailDtos().Data)
            {
                Console.WriteLine(car.BrandName + "-_-" + car.ColorName);
            }
        }
    }

}
