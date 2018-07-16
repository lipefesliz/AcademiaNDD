using FluentAssertions;
using MediaProva.Common.Tests.Base;
using MediaProva.Common.Tests.Features.Alunos;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Infra.Data.Base;
using MediaProva.Infra.Data.Features.Alunos;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace MediaProva.Infra.Data.Tests.Features.Alunos
{
    [TestFixture]
    public class AlunoRepositoryTestes
    {
        MediaProvaContext _contexto;
        AlunoRepository _repositorio;
        Aluno _aluno;

        [SetUp]
        public void SetUp()
        {
            _contexto = new MediaProvaContext();
            _repositorio = new AlunoRepository(_contexto);
            _aluno = AlunoObjectMother.CriarAlunoValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Aluno_InfraData_Add_Deve_Inserir_Aluno()
        {
            //Cenario

            //Acao
            _aluno = _repositorio.Add(_aluno);

            //Verificacao
            _aluno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Aluno_InfraData_Get_Deve_Obter_Aluno_PorId()
        {
            //Cenario
            _aluno = _repositorio.Add(_aluno);

            //Acao
            var alunoObtido = _repositorio.Get(_aluno.Id);

            //Verificacao
            alunoObtido.Id.Should().Be(_aluno.Id);
        }

        [Test]
        public void Teste_Aluno_InfraData_GetAll_Deve_Obter_Todos_Alunos()
        {
            //Cenario
            _aluno.Id = 1;

            //Acao
            var alunos = _repositorio.GetAll();

            //Verificacao
            alunos.Count().Should().BeGreaterThan(0);
            alunos.First().Id.Should().Be(_aluno.Id);
        }

        [Test]
        public void Teste_Aluno_InfraData_Delete_Deve_Deletar_Aluno()
        {
            //Cenario
            var id = 1;
            _aluno = _repositorio.Get(id);

            //Acao
            _repositorio.Delete(_aluno);
            var alunoExcluido = _repositorio.Get(_aluno.Id);

            //Verificacao
            alunoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Aluno_InfraData_Update_Deve_Atualizar_Aluno()
        {
            //Cenario
            _aluno = _repositorio.Add(_aluno);
            _aluno.Nome = "atualizado";

            //Acao
            var alunoAtualizado = _repositorio.Update(_aluno);

            //Verificacao
            alunoAtualizado.Nome.Should().Be(_aluno.Nome);
        }
    }
}
