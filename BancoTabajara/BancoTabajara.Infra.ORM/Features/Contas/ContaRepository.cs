using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Infra.ORM.Base;
using BancoTabajara.Infra.ORM.Contexts;
using System.Linq;

namespace BancoTabajara.Infra.ORM.Features.Contas
{
    public class ContaRepository : AbstractRepository<Conta>, IContaRepository
    {
        public ContaRepository(BancoTabajaraDbContext context) : base(context)
        {
        }

        public new IQueryable<Conta> GetAll(int? quantidade = null)
        {
            if (quantidade != null)
                return _context.Contas.Include("CLiente").Take((int)quantidade);

            return _context.Contas.Include("Cliente").AsQueryable();
        }

        public new bool Remove(long contaId)
        {
            var contaDb = _context.Contas.Where(c => c.Id == contaId).FirstOrDefault();

            _context.Movimentacoes.RemoveRange(contaDb.Movimentacoes);
            _context.Contas.Remove(contaDb);

            return _context.SaveChanges() > 0;
        }
    }
}
