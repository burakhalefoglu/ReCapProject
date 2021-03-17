using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto);
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IDataResult<User> UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
