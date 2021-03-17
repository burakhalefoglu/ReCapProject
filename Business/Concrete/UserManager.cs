using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal usersDal;

        public UserManager(IUserDal usersDal)
        {
            this.usersDal = usersDal;
        }


        public IResult AddUser(User user)
        {
            usersDal.Add(user);
            return new SuccessResult();
        }

        public IResult DeleteUser(User user)
        {
            usersDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAllUser()
        {
            var result = usersDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }

        public IResult UpdateUser(User user)
        {
            usersDal.Update(user);
            return new SuccessResult();
        }

        public IDataResult<List<UserOperationClaimsDto>> GetOperationClaims(User user)
        {
            var result =  usersDal.GetOperationClaims(user.Id);
            return new SuccessDataResult<List<UserOperationClaimsDto>>(result);
        }

        public IDataResult<User> GetByEmail(string email)
        {

            var result = usersDal.Get(u => u.Email == email);

            return new SuccessDataResult<User>(result);
        }
    }
}
