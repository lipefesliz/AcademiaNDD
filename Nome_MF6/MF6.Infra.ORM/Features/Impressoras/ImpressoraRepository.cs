using MF6.Domain.Features.Impressoras;
using MF6.Infra.ORM.Base;
using MF6.Infra.ORM.Contexts;

namespace MF6.Infra.ORM.Features.Impressoras
{
    public class ImpressoraRepository : AbstractRepository<Impressora>, IImpressoraRepository
    {
        public ImpressoraRepository(MF6Context context) : base(context)
        {
        }
    }
}
