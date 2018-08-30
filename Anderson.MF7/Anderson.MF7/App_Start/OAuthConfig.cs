using Anderson.MF7.Infra.Settings;
using Anderson.MF7.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace Anderson.MF7.App_Start
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
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(AndersonMF7Settings.AuthenticationSettings.TokenExpiration),
                Provider = new OAuthProvider(),

            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}