using BancoTabajara.Domain.Features.Movimentacoes;
using BancoTabajara.Infra.ORM.Base;
using BancoTabajara.Infra.ORM.Contexts;

namespace BancoTabajara.Infra.ORM.Features.Movimentacoes
{
    public class MovimentacaoRepository : AbstractRepository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(BancoTabajaraDbContext context) : base(context)
        {
        }
    }
}
