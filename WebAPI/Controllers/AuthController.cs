using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {

            var userlogin = _authService.Login(userLoginDto);
            if (!userlogin.Success)
            {
                return BadRequest(userlogin.Message);
            }
            var result = _authService.CreateAccessToken(userlogin.Data);
            if (result.Success)
            {
                return Ok(result.Data); 
            }
            return BadRequest(result.Message);

        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var userExistResult = _authService.UserExist(userRegisterDto.Email);
            if (!userExistResult.Success)
            {
                return BadRequest(userExistResult.Message);
            }

            var userRegisterResult = _authService.Register(userRegisterDto);
            if (!userRegisterResult.Success)
            {
                return BadRequest(userRegisterResult.Message);
            }
            var accessTokenResult = _authService.CreateAccessToken(userRegisterResult.Data);
            if (accessTokenResult.Success)
            {
                return Ok(accessTokenResult.Data);
            }
            return BadRequest(accessTokenResult.Message);
        }
    }
}
