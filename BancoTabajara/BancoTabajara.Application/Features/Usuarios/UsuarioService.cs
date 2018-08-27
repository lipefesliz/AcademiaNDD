using BancoTabajara.Domain.Exceptions;
using BancoTabajara.Domain.Features.Usuarios;
using System.Linq;

namespace BancoTabajara.Application.Features.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public long Add(Usuario usuario)
        {
            var novoUsuario = _repository.Add(usuario);

            return novoUsuario.Id;
        }

        public IQueryable<Usuario> GetAll(int? quantidade = null)
        {
            return _repository.GetAll(quantidade);
        }

        public Usuario GetById(long id)
        {
            var usuarioDb = _repository.GetbyId(id) ?? throw new NotFoundException();

            return usuarioDb;
        }

        public Usuario GetByLogin(string username, string password)
        {
            var usuarioDb = _repository.GetByLogin(username, password) ?? throw new NotFoundException();

            return usuarioDb;
        }

        public bool Remove(Usuario usuario)
        {
            var usuarioDb = _repository.GetbyId(usuario.Id) ?? throw new NotFoundException();

            return _repository.Remove(usuarioDb.Id);
        }

        public bool Update(Usuario usuario)
        {
            var usuarioDb = _repository.GetbyId(usuario.Id) ?? throw new NotFoundException();

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Senha = usuario.Senha;

            return _repository.Update(usuarioDb);
        }
    }
}
