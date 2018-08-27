using BancoTabajara.Domain.Exceptions;
using BancoTabajara.Domain.Features.Usuarios;
using BancoTabajara.Infra.ORM.Base;
using BancoTabajara.Infra.ORM.Contexts;
using System.Linq;

namespace BancoTabajara.Infra.ORM.Features.Usuarios
{
    public class UsuarioRepository : AbstractRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BancoTabajaraDbContext context) : base(context)
        {
        }

        public Usuario GetByLogin(string username, string password)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Nome == username && u.Senha == password) ?? throw new InvalidCredentialsException();

            return user;
        }
    }
}
