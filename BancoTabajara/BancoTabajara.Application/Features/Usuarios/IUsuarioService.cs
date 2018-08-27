using BancoTabajara.Domain.Features.Usuarios;
using System.Linq;

namespace BancoTabajara.Application.Features.Usuarios
{
    public interface IUsuarioService
    {
        long Add(Usuario usuario);

        bool Update(Usuario usuario);

        Usuario GetById(long id);

        Usuario GetByLogin(string username, string password);

        IQueryable<Usuario> GetAll(int? quantidade = null);

        bool Remove(Usuario usuario);
    }
}
