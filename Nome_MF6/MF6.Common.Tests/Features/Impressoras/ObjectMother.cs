using MF6.Domain.Features.Impressoras;
using MF6.Domain.Features.Toners;

namespace MF6.Common.Tests.Features.Impressoras
{
    public static partial class ObjectMother
    {
        public static Impressora ObterImpressoraValida()
        {
            return new Impressora
            {
                Id = 2,
                EmUso = true,
                TonerColorido = new Toner()
                {
                    Id = 2,
                },
                TonerPreto = new Toner()
                {
                    Id = 3,
                },
                Marca = "marca",
                Rede = "rede",
            };
        }
    }
}
