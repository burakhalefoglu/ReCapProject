using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CardbContext context = new CardbContext())
            {
                var Addedobj = context.Entry(entity);
                Addedobj.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Car entity)
        {
            using (CardbContext context = new CardbContext())
            {
                var DeletedObj = context.Entry(entity);
                DeletedObj.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CardbContext context = new CardbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CardbContext context = new CardbContext())
            {
                return filter == null
                      ? context.Set<Car>().ToList()
                      : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CardbContext context = new CardbContext())
            {
                var UpdatedObj = context.Entry(entity);
                UpdatedObj.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
