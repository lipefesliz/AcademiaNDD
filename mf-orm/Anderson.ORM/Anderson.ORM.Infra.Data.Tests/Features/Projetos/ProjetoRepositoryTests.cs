using Anderson.ORM.Common.Tests.Base;
using Anderson.ORM.Common.Tests.Features.Projetos;
using Anderson.ORM.Domain.Features.Projetos;
using Anderson.ORM.Infra.Data.Base;
using Anderson.ORM.Infra.Data.Features.Projetos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Tests.Features.Projetos
{
    [TestFixture]
    public class ProjetoRepositoryTests
    {
        AndersonORMContext _contexto;
        ProjetoRepository _repositorio;
        Projeto _projeto;

        [SetUp]
        public void SetUp()
        {
            _contexto = new AndersonORMContext();
            _repositorio = new ProjetoRepository(_contexto);
            _projeto = ProjetoObjectMother.CriarProjetoValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Projeto_InfraData_Add_Deve_Inserir_Projeto()
        {
            //Cenario

            //Acao
            _projeto = _repositorio.Add(_projeto);

            //Verificacao
            _projeto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Projeto_InfraData_Get_Deve_Obter_Projeto_PorId()
        {
            //Cenario
            _projeto = _repositorio.Add(_projeto);

            //Acao
            var projetoObtido = _repositorio.Get(_projeto.Id);

            //Verificacao
            projetoObtido.Id.Should().Be(_projeto.Id);
        }

        [Test]
        public void Teste_Projeto_InfraData_GetAll_Deve_Obter_Todos_Projetos()
        {
            //Cenario
            _projeto.Id = 1;

            //Acao
            var projetos = _repositorio.GetAll();

            //Verificacao
            projetos.Count().Should().BeGreaterThan(0);
            projetos.First().Id.Should().Be(_projeto.Id);
        }

        [Test]
        public void Teste_Projeto_InfraData_Delete_Deve_Deletar_Projeto()
        {
            //Cenario
            _projeto = _repositorio.Add(_projeto);

            //Acao
            _repositorio.Delete(_projeto);
            var departamentoExcluido = _repositorio.Get(_projeto.Id);

            //Verificacao
            departamentoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Projeto_InfraData_Update_Deve_Atualizar_Projeto()
        {
            //Cenario
            _projeto = _repositorio.Add(_projeto);
            _projeto.Nome = "atualizado";

            //Acao
            var projetoAtualizado = _repositorio.Update(_projeto);

            //Verificacao
            projetoAtualizado.Nome.Should().Be(_projeto.Nome);
        }
    }
}
