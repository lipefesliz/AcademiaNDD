using Anderson.MF7.Application.Features.Gastos.Commands;
using Anderson.MF7.Application.Features.Gastos.Queries;
using Anderson.MF7.Domain.Features.Gastos;
using System.Linq;

namespace Anderson.MF7.Application.Features.Gastos
{
    public interface IGastoService
    {
        long Add(GastoRegisterCommand cmd);

        Gasto GetById(long id);

        IQueryable<Gasto> GetAll(GastoQuery query);

        bool Remove(GastoRemoveCommand cmd);
    }
}
