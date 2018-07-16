using FluentAssertions;
using MediaProva.Application.Alunos;
using MediaProva.Common.Tests.Base;
using MediaProva.Common.Tests.Features.Alunos;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Infra.Data.Base;
using MediaProva.Infra.Data.Features.Alunos;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace MediaProva.Integration.Tests.Features.Alunos
{
    [TestFixture]
    public class AlunoIntegrationTests
    {
        MediaProvaContext _context;
        AlunoRepository _repositorio;
        AlunoService _servico;
        Aluno _aluno;

        [SetUp]
        public void SetUp()
        {
            _context = new MediaProvaContext();
            _repositorio = new AlunoRepository(_context);
            _servico = new AlunoService(_repositorio);
            _aluno = AlunoObjectMother.CriarAlunoValido();
            Database.SetInitializer(new BaseSqlTest());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Teste_Aluno_Integracao_Add_Deve_Inserir_Aluno()
        {
            //Cenario

            //Acao
            _aluno = _servico.Add(_aluno);

            //Verificacao
            _aluno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Aluno_Integracao_Get_Deve_Obter_Aluno_PorId()
        {
            //Cenario
            _aluno = _servico.Add(_aluno);

            //Acao
            var alunoObtido = _servico.Get(_aluno.Id);

            //Verificacao
            alunoObtido.Id.Should().Be(_aluno.Id);
        }

        [Test]
        public void Teste_Aluno_Integracao_GetAll_Deve_Obter_Todos_Alunos()
        {
            //Cenario
            _aluno.Id = 1;

            //Acao
            var alunos = _servico.GetAll();

            //Verificacao
            alunos.Count().Should().BeGreaterThan(0);
            alunos.First().Id.Should().Be(_aluno.Id);
        }

        [Test]
        public void Teste_Aluno_Integracao_Delete_Deve_Deletar_Aluno()
        {
            //Cenario
            var id = 1;
            _aluno = _servico.Get(id);

            //Acao
            _servico.Delete(_aluno);
            var alunoExcluido = _servico.Get(_aluno.Id);

            //Verificacao
            alunoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Aluno_Integracao_Update_Deve_Atualizar_Aluno()
        {
            //Cenario
            _aluno = _servico.Add(_aluno);
            _aluno.Nome = "atualizado";

            //Acao
            var alunoAtualizado = _servico.Update(_aluno);

            //Verificacao
            alunoAtualizado.Nome.Should().Be(_aluno.Nome);
        }
    }
}
