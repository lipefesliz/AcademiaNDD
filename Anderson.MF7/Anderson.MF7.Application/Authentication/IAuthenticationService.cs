using Anderson.MF7.Domain.Features.Funcionarios;

namespace Anderson.MF7.Application.Authentication
{
    public interface IAuthenticationService
    {
        Funcionario Login(string email, string password);
    }
}
