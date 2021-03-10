using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CardbContext>, ICarDal
    {
        public List<CarDetailDto> carDetailDtos()
        {
            using (CardbContext context = new CardbContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             join brnd in context.Brands
                             on c.BrandId equals brnd.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = brnd.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
                            
            }
        }
    }
}
