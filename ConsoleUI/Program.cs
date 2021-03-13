using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    
    class Program
    {
        static void Main(string[] args)
        {
            AddCustomer();
        }

        private static void AddCustomer()
        {
            User user = new User
            {
                Email = "burakhalefoglu@example.com",
                FirstName = "burak",
                LastName = "Halefoğlu",
                Password = "12345"

            };


            UserManager userManager = new UserManager(new EfUserDal());
            userManager.AddUser(user);

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            user.customer = new Customer { UserId = user.Id, CompanyName = "CompanyA" };
            customerManager.AddCustomer(user.customer);
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
