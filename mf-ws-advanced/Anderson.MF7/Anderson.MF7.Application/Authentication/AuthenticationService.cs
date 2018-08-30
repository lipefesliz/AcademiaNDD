using Anderson.MF7.Domain.Features.Users;
using Anderson.MF7.Infra.Crypto;

namespace Anderson.MF7.Application.Authentication
{
    public class AuthenticationService
    {
        private IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string username, string password)
        {
            return _userRepository.GetUser(username, password);
        }
    }
}
