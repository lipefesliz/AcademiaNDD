using Anderson.ORM.Domain.Features.Cargos;

namespace Anderson.ORM.Common.Tests.Features.Cargos
{
    public static class CargoObjectMother
    {
        public static Cargo CriarCargoValido()
        {
            var cargo = new Cargo();

            cargo.Descricao = "Dev";

            return cargo;
        }
    }
}
