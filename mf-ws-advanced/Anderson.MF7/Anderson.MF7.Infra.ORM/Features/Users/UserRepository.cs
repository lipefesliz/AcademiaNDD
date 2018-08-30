using Anderson.MF7.Domain.Exceptions;
using Anderson.MF7.Domain.Features.Users;
using Anderson.MF7.Infra.ORM.Contexts;
using System.Linq;

namespace Anderson.MF7.Infra.ORM.Features.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AndersonMF7DbContext _context;

        public UserRepository(AndersonMF7DbContext context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password == password) ?? throw new InvalidCredentialsException();
            return user;
        }
    }
}
