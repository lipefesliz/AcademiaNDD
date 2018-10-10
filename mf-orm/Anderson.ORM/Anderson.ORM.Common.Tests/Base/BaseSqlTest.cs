using Anderson.ORM.Common.Tests.Features.Cargos;
using Anderson.ORM.Common.Tests.Features.Departamentos;
using Anderson.ORM.Common.Tests.Features.Dependentes;
using Anderson.ORM.Common.Tests.Features.Enderecos;
using Anderson.ORM.Common.Tests.Features.Funcionarios;
using Anderson.ORM.Common.Tests.Features.Projetos;
using Anderson.ORM.Infra.Data.Base;
using System.Data.Entity;

namespace Anderson.ORM.Common.Tests.Base
{
    public class BaseSqlTest : DropCreateDatabaseAlways<AndersonORMContext>
    {
        protected override void Seed(AndersonORMContext context)
        {
            var cargo = context.Cargos.Add(CargoObjectMother.CriarCargoValido());
            var departamento = context.Departamentos.Add(DepartamentoObjectMother.CriarDepartamentoValido());
            var endereco = context.Enderecos.Add(EnderecoObjectMother.CriarEnderecoValido());
            var funcionario = context.Funcionarios.Add(FuncionarioObjectMother.CriarFuncionarioValido
                (cargo, departamento, endereco));
            var dependente = context.Dependentes.Add(DependenteObjectMother.CriarDependenteValido(funcionario));
            context.Projetos.Add(ProjetoObjectMother.CriarProjetoValido(funcionario));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
