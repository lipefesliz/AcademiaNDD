using Anderson.ORM.Common.Tests.Base;
using Anderson.ORM.Common.Tests.Features.Dependentes;
using Anderson.ORM.Domain.Features.Dependentes;
using Anderson.ORM.Infra.Data.Base;
using Anderson.ORM.Infra.Data.Features.Dependentes;
using Anderson.ORM.Infra.Data.Features.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Tests.Features.Dependentes
{
    [TestFixture]
    public class DependenteRepositoryTests
    {
        AndersonORMContext _contexto;
        DependenteRepository _repositorio;
        FuncionarioRepository _funcionarioRepositorio;
        Dependente _dependente;

        [SetUp]
        public void SetUp()
        {
            _contexto = new AndersonORMContext();
            _repositorio = new DependenteRepository(_contexto);
            _funcionarioRepositorio = new FuncionarioRepository(_contexto);
            _dependente = DependenteObjectMother.CriarDependenteValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Dependente_InfraData_Add_Deve_Inserir_Dependente()
        {
            //Cenario
            var id = 1;
            var funcionario = _funcionarioRepositorio.Get(id);
            _dependente.Funcionario = funcionario;

            //Acao
            _dependente = _repositorio.Add(_dependente);

            //Verificacao
            _dependente.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Dependente_InfraData_Get_Deve_Obter_Dependente_PorId()
        {
            //Cenario
            var id = 1;
            var funcionario = _funcionarioRepositorio.Get(id);
            _dependente.Funcionario = funcionario;
            _dependente = _repositorio.Add(_dependente);

            //Acao
            var dependenteObtido = _repositorio.Get(_dependente.Id);

            //Verificacao
            dependenteObtido.Id.Should().Be(_dependente.Id);
        }

        [Test]
        public void Teste_Dependente_InfraData_GetAll_Deve_Obter_Todos_Dependentes()
        {
            //Cenario
            _dependente.Id = 1;

            //Acao
            var dependentes = _repositorio.GetAll();

            //Verificacao
            dependentes.Count().Should().BeGreaterThan(0);
            dependentes.First().Id.Should().Be(_dependente.Id);
        }

        [Test]
        public void Teste_Dependente_InfraData_Delete_Deve_Deletar_Dependente()
        {
            //Cenario
            var id = 1;
            var funcionario = _funcionarioRepositorio.Get(id);
            _dependente.Funcionario = funcionario;
            _dependente = _repositorio.Add(_dependente);

            //Acao
            _repositorio.Delete(_dependente);
            var dependenteExcluido = _repositorio.Get(_dependente.Id);

            //Verificacao
            dependenteExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Dependente_InfraData_Update_Deve_Atualizar_Dependente()
        {
            //Cenario
            var id = 1;
            var funcionario = _funcionarioRepositorio.Get(id);
            _dependente.Funcionario = funcionario;
            _dependente = _repositorio.Add(_dependente);
            _dependente.Nome = "atualizado";

            //Acao
            var dependenteAtualizado = _repositorio.Update(_dependente);

            //Verificacao
            dependenteAtualizado.Nome.Should().Be(_dependente.Nome);
        }

        [Test]
        public void Teste_Dependente_InfraData_ObterPorFuncionario_Deve_Obter_Dependentes()
        {
            //Cenario
            var id = 1;
            var funcionario = _funcionarioRepositorio.Get(id);
            _dependente.Funcionario = funcionario;
            _dependente = _repositorio.Add(_dependente);

            //Acao
            var dependentes = _repositorio.ObterPorFuncionario(funcionario.Nome);

            //Verificacao
            dependentes.Count().Should().BeGreaterThan(0);
            dependentes.First().Funcionario.Should().Be(_dependente.Funcionario);
        }
    }
}
