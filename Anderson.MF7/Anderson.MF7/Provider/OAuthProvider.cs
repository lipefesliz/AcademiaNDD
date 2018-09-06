using Anderson.MF7.Application.Authentication;
using Anderson.MF7.Domain.Features.Funcionarios;
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
        public OAuthProvider() : base()
        {
        }

        /// <summary>
        /// É responsável por fazer validações extras.
        /// Garantindo que o cliente é o que diz ser.
        /// Você faria isso, talvez, se tiver registrado o cliente em um servidor de autorização e precisar verificar se ele ainda é válido.
        /// </summary>
        /// <param name="context">É o contexto atual da chamada http na visão do oauth</param>
        /// <returns>Retorna se é válido (true) ou não (false)</returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Alow-Origin", new[] { "*" });

            var funcionario = default(Funcionario);

            try
            {
                var authService = SimpleInjectorContainer.ContainerInstance.GetInstance<IAuthenticationService>();
                funcionario = authService.Login(context.UserName, context.Password);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim("FuncionarioId", funcionario.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, funcionario.Usuario));

            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }
    }
}