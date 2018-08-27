using BancoTabajara.Domain.Base;

namespace BancoTabajara.Domain.Features.Usuarios
{
    public class Usuario : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
