using BancoTabajara.Auth;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace BancoTabajara.App_Start
{
    public static class OAuthConfig
    {
        /// <summary>
        /// Método que configura e inicializa a disponibilização de tokens
        /// </summary>
        public static void ConfigureOAuth(IAppBuilder app)
        {
            ConfigureOAuthTokenGeneration(app);
        }

        private static void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //Somente para ambiente DEV (Em produção deve ser AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                // Indica que o token será obtido através de: <url>/token
                TokenEndpointPath = new PathString("/token"),
                // Tempo de expiração do token
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                // Informa o nosso provedor customizado
                Provider = new AccessTokensProvider(),

            };

            // Disponibiliza o OAuth 2.0 Bearer Access Token Generation na aplicação com as configurações acima
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}