using MF6.Domain.Features.Impressoras;
using MF6.Domain.Features.Toners;

namespace MF6.Application.Features.Impressoras
{
    public class Nivelador
    {
        public double Quantidade { get; set; }
        public TipoOperacao Operacao { get; set; }
        public int ImpressoraID { get; set; }
    }
}
