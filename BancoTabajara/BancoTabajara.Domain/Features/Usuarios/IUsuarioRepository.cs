using BancoTabajara.Domain.Base;

namespace BancoTabajara.Domain.Features.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByLogin(string username, string password);
    }
}
