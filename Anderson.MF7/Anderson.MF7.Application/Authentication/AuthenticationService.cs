using Anderson.MF7.Domain.Features.Funcionarios;

namespace Anderson.MF7.Application.Authentication
{
    /// <summary>
    /// Serviço de autenticação de usuários
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private IFuncionarioRepository _funcionarioRepository;

        public AuthenticationService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public Funcionario Login(string username, string password)
        {
            //password = password.GenerateHash();
            return _funcionarioRepository.GetByCredentials(username, password);
        }
    }
}
