﻿using Anderson.MF7.Domain.Features.Users;

namespace Anderson.MF7.Application.Authentication
{
    /// <summary>
    /// Serviço de autenticação de usuários
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        ///  Método para realizar o login, ou seja, validação de credenciais de autenticação.
        /// </summary>
        /// <param name="email">É o email do usuário cadastrado</param>
        /// <param name="password">É a senha do usuário que foi cadastrado</param>
        /// <returns>O usuário que corresponde as credenciais informadas. Caso alguma esteja inválida, retorna null</returns>
        public User Login(string email, string password)
        {
            //password = password.GenerateHash();
            return _userRepository.GetByCredentials(email, password);
        }
    }
}
