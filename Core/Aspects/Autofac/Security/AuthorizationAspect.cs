using Castle.DynamicProxy;
using Core.Extentions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Security
{
    public class AuthorizationAspect : MethodInterception
    {
        string[] _roles;
        private IHttpContextAccessor _contextAccessor;
        public AuthorizationAspect( string roles)
        {
            _roles = roles.Split(",");
            _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _contextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Messages.AuthorizationDenied");
        }

    }
}
