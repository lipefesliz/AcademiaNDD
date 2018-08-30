using Anderson.MF7.Domain.Base;

namespace Anderson.MF7.Domain.Features.Users
{
    /// <summary>
    /// Representa um User como entidade de negócio
    /// </summary>
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
