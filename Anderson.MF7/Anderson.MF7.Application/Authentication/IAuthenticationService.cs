using Anderson.MF7.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anderson.MF7.Application.Authentication
{
    public interface IAuthenticationService
    {
        User Login(string email, string password);
    }
}
