using Anderson.MF7.Infra.Settings.Entities;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Anderson.MF7.Infra.Settings
{
    /// <summary>
    /// Fornece configurações transversais (para todas as layers) do AndersonMF7Server
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class AndersonMF7Settings
    {
        #region private fields
        static AuthenticationSettings _authSettings;
        #endregion private fields

        /// <summary>
        /// Fornece as configurações de autenticação que estão dispostas no Web.config
        /// </summary>
        public static AuthenticationSettings AuthenticationSettings
        {
            get
            {
                return _authSettings ?? ((AuthenticationSettings)ConfigurationManager.GetSection("Anderson.MF7/AuthenticationSettings"));
            }
        }
    }
}
