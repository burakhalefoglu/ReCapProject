using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;
using Core.Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CardbContext>, IUserDal
    {
       

        public List<UserOperationClaimsDto> GetOperationClaims(int id)
        {
            using (CardbContext context = new CardbContext())
            {
                var result = from u in context.Users
                             join oc in context.UserOperationClaims
                             on u.Id equals id
                             join uoc in context.OperationClaims
                             on oc.OperationClaimId equals uoc.Id
                             select new UserOperationClaimsDto
                             {
                                 UserId = u.Id,
                                 OperationClaimName = uoc.Name
                             };



                return result.ToList();
            }
        }
    }
}
