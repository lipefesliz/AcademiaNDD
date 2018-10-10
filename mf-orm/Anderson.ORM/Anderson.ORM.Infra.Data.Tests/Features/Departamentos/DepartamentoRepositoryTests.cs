using Anderson.ORM.Common.Tests.Base;
using Anderson.ORM.Common.Tests.Features.Departamentos;
using Anderson.ORM.Domain.Features.Departamentos;
using Anderson.ORM.Infra.Data.Base;
using Anderson.ORM.Infra.Data.Features.Departamentos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Tests.Features.Departamentos
{
    [TestFixture]
    public class DepartamentoRepositoryTests
    {
        AndersonORMContext _contexto;
        DepartamentoRepository _repositorio;
        Departamento _departamento;

        [SetUp]
        public void SetUp()
        {
            _contexto = new AndersonORMContext();
            _repositorio = new DepartamentoRepository(_contexto);
            _departamento = DepartamentoObjectMother.CriarDepartamentoValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Departamento_InfraData_Add_Deve_Inserir_Departamento()
        {
            //Cenario

            //Acao
            _departamento = _repositorio.Add(_departamento);

            //Verificacao
            _departamento.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Departamento_InfraData_Get_Deve_Obter_Departamento_PorId()
        {
            //Cenario
            _departamento = _repositorio.Add(_departamento);

            //Acao
            var departamentoObtido = _repositorio.Get(_departamento.Id);

            //Verificacao
            departamentoObtido.Id.Should().Be(_departamento.Id);
        }

        [Test]
        public void Teste_Departamento_InfraData_GetAll_Deve_Obter_Todos_Departamentos()
        {
            //Cenario
            _departamento.Id = 1;

            //Acao
            var departamentos = _repositorio.GetAll();

            //Verificacao
            departamentos.Count().Should().BeGreaterThan(0);
            departamentos.First().Id.Should().Be(_departamento.Id);
        }

        [Test]
        public void Teste_Departamento_InfraData_Delete_Deve_Deletar_Departamento()
        {
            //Cenario
            _departamento = _repositorio.Add(_departamento);

            //Acao
            _repositorio.Delete(_departamento);
            var departamentoExcluido = _repositorio.Get(_departamento.Id);

            //Verificacao
            departamentoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Departamento_InfraData_Update_Deve_Atualizar_Departamento()
        {
            //Cenario
            _departamento = _repositorio.Add(_departamento);
            _departamento.Descricao = "atualizado";

            //Acao
            var departamentoAtualizado = _repositorio.Update(_departamento);

            //Verificacao
            departamentoAtualizado.Descricao.Should().Be(_departamento.Descricao);
        }
    }
}
