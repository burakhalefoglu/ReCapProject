using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,
                           ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }


        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var token = _tokenHelper.CreateToken(user, _userService.GetOperationClaims(user).Data);
            return new SuccessDataResult<AccessToken>(token, Messages.DefaultSuccess);
        }


        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Messages.UserNotFound");
            }

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Messages.PasswordError");
            }

            return new SuccessDataResult<User>(userToCheck.Data, "Messages.SuccessfulLogin");
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Statuse = true
            };
            _userService.AddUser(user);
            return new SuccessDataResult<User>(user, Messages.DefaultSuccess);
        }

        public IDataResult<User> UserExist(string email)
        {
            var  user = _userService.GetByEmail(email);
            if (user.Data != null)
            {
                return new ErrorDataResult<User>(Messages.DefaultError);
            }
            return new SuccessDataResult<User>();
        }
    }
}
