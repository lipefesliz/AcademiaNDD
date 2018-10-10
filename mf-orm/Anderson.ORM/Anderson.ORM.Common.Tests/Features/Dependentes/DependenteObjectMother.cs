using Anderson.ORM.Domain.Features.Dependentes;
using Anderson.ORM.Domain.Features.Funcionarios;

namespace Anderson.ORM.Common.Tests.Features.Dependentes
{
    public static class DependenteObjectMother
    {
        public static Dependente CriarDependenteValido()
        {
            var dependente = new Dependente();

            dependente.Nome = "nome";
            dependente.Idade = 20;
            dependente.Funcionario = new Funcionario();

            return dependente;
        }

        public static Dependente CriarDependenteValido(Funcionario funcionario)
        {
            var dependente = new Dependente();

            dependente.Nome = "nome";
            dependente.Idade = 20;
            dependente.Funcionario = funcionario;

            return dependente;
        }
    }
}
