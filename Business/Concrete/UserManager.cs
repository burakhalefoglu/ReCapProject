using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUsersDal usersDal;

        public UserManager(IUsersDal usersDal)
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
    }
}
