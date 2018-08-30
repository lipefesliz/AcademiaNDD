using MF6.Application.Base;
using MF6.Domain.Features.Impressoras;

namespace MF6.Application.Features.Impressoras
{
    public interface IImpressoraService : IService<Impressora>
    {
        bool UpdateNivelColorido(Nivelador nivelador);
        bool UpdateNivelPreto(Nivelador nivelador);
    }
}
