using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {

        IDataResult<List<User>> GetAllUser();
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
        IResult AddUser(User user);
        IDataResult<User> GetByEmail(string Email);
        IDataResult<List<UserOperationClaimsDto>> GetOperationClaims(User user);

    }
}
