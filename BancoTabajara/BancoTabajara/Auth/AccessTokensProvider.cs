using BancoTabajara.Application.Features.Usuarios;
using BancoTabajara.IoC;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BancoTabajara.Auth
{
    public class AccessTokensProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var usuarioService = SimpleInjectorContainer.Container.GetInstance<IUsuarioService>();

            var usuario = usuarioService.GetByLogin(context.UserName, context.Password);

            if (usuario == null)
            {
                context.SetError("invalid_grant", "Usuário não encontrado um senha incorreta.");
                return;
            }

            var userIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(userIdentity);
        }
    }
}