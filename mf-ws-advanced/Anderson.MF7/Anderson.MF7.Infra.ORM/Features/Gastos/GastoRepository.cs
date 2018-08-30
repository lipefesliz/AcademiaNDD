using Anderson.MF7.Domain.Features.Gastos;
using Anderson.MF7.Infra.ORM.Base;
using Anderson.MF7.Infra.ORM.Contexts;
using System.Linq;

namespace Anderson.MF7.Infra.ORM.Features.Gastos
{
    public class GastoRepository : AbstractRepository<Gasto>, IGastoRepository
    {
        public GastoRepository(AndersonMF7DbContext context) : base(context)
        {
        }

        public new IQueryable<Gasto> GetAll(int? quantidade = null)
        {
            if (quantidade != null)
                return _context.Gastos.Include("Funcionario").Take((int)quantidade);

            return _context.Gastos.Include("Funcionario").AsQueryable();
        }
    }
}
