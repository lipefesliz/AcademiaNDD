using System.Diagnostics.CodeAnalysis;

namespace Anderson.MF7.Infra.Settings.Entities
{
    /// <summary>
    /// Representa as configurações da autenticação providas pela Anderson.MF7.Infra
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AuthenticationSettings
    {
        /// <summary>
        /// Configuração de expiração do token de autenticação, em dias.
        /// </summary>
        public int TokenExpiration { get; set; }
        public string AudienceId { get; set; }
        public string AudienceSecret { get; set; }
        public string Issuer { get; set; }
    }
}
