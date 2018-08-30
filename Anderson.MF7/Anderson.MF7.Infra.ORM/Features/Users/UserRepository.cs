using Anderson.MF7.Domain.Exceptions;
using Anderson.MF7.Domain.Features.Users;
using Anderson.MF7.Infra.ORM.Contexts;
using System.Linq;

namespace Anderson.MF7.Infra.ORM.Features.Users
{
    /// <summary>
    ///  Repositório de usuários
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AndersonMF7DbContext _context;

        public UserRepository(AndersonMF7DbContext context)
        {
            _context = context;
        }

        public User GetByCredentials(string email, string password)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Email.Equals(email) && u.Password == password) ?? throw new InvalidCredentialsException();

            return user;
        }
    }
}
