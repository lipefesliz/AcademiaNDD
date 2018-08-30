using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anderson.MF7.Domain.Features.Users
{
    /// <summary>
    /// Representa o repositório de usuários
    /// </summary>
    public interface IUserRepository
    {
        User GetByCredentials(string email, string password);
    }
}
