using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfColorDal : EfEntityRepositoryBase<Color, CardbContext>, IColorDal
    {
    }
}
