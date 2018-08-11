using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Infra.ORM.Base;
using BancoTabajara.Infra.ORM.Contexts;

namespace BancoTabajara.Infra.ORM.Features.Clientes
{
    public class ClienteRepository : AbstractRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BancoTabajaraDbContext context) : base(context)
        {
        }
    }
}
