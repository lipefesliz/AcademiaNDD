using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anderson.MF7.Domain.Features.Users
{
    /// <summary>
    /// Representa um User como entidade de negócio
    /// </summary>
    public class User : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
