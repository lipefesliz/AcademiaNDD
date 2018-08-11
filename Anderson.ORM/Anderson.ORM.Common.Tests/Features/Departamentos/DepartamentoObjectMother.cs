using Anderson.ORM.Domain.Features.Departamentos;

namespace Anderson.ORM.Common.Tests.Features.Departamentos
{
    public static class DepartamentoObjectMother
    {
        public static Departamento CriarDepartamentoValido()
        {
            var departamento = new Departamento();

            departamento.Descricao = "Desenvolvimento";

            return departamento;
        }
    }
}
