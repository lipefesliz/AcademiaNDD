using Anderson.MF7.Domain.Features.Users;

namespace Anderson.MF7.Application.Authentication
{
    public interface IAuthenticationService
    {
        User Login(string email, string password);
    }
}
