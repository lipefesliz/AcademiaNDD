using Anderson.MF7.Application.Authentication;
using Anderson.MF7.Domain.Features.Users;
using Anderson.MF7.IoC;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Anderson.MF7.Provider
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = default(User);

            try
            {
                var authService = SimpleInjectorContainer.ContainerInstance.GetInstance<AuthenticationService>();

                user = authService.Login(context.UserName, context.Password);
            }
            catch (Exception)
            {
                context.SetError("invalid_grant", "User not found.");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim("UserId", user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }
    }
}