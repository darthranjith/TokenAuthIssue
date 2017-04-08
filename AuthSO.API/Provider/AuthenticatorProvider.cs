using AuthSO.Core.Interface;
using AuthSO.Core.Manager;
using AuthSO.Data.Repository;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AuthSO.API.Provider
{
    public class AuthenticatorProvider : OAuthAuthorizationServerProvider
    {
        private IAuthenticator _authService;
        public IAuthenticator AuthService
        {
            get { return (IAuthenticator)(_authService ?? GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthenticator))); }
            set { _authService = value; }
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                if (!AuthService.Authenticate(context.UserName, context.Password))
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
           

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }
    }
}