using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Extentions;
using Core.Utilities.Security.Encyrption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration _configuration { get; set; }
        public TokenOptions _tokenOptions { get; set; }
        public DateTime _expireTime { get; set; }


        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        public AccessToken CreateToken(User user, List<UserOperationClaimsDto> userOperationClaimsDtos)
        {
            _expireTime = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredential = SigningCredentialHelper.CreateSigningCredential(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,
                                               user,
                                               signingCredential,
                                               userOperationClaimsDtos);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                ExpireTime = _expireTime
            };

        }


        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,
                                                        User user,
                                                        SigningCredentials signingCredentials,
                                                        List<UserOperationClaimsDto> userOperationClaimsDtos)
        {

            var jwt = new JwtSecurityToken(

                issuer: tokenOptions.Issuser,
                audience: tokenOptions.Audience,
                expires: _expireTime,
                notBefore: DateTime.Now,
                claims: SetClaims(user, userOperationClaimsDtos),
                signingCredentials: signingCredentials

                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<UserOperationClaimsDto> userOperationClaimsDtos)
        {

            var claim = new List<Claim>();
            claim.AddEmail(user.Email);
            claim.AddName($"{user.FirstName} {user.LastName}");
            claim.AddNameIdentifier(user.Id.ToString());
            claim.AddRoles(userOperationClaimsDtos.Select(role => role.OperationClaimName).ToArray());
            return claim;
        }
    }
}
