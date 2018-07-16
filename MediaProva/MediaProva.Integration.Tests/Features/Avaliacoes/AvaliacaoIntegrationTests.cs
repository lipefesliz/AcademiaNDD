using FluentAssertions;
using MediaProva.Application.Avaliacoes;
using MediaProva.Common.Tests.Base;
using MediaProva.Common.Tests.Features.Alunos;
using MediaProva.Common.Tests.Features.Avaliacoes;
using MediaProva.Common.Tests.Features.Resultados;
using MediaProva.Domain.Exceptions;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Domain.Features.Resultados;
using MediaProva.Infra.Data.Base;
using MediaProva.Infra.Data.Features.Avaliacoes;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Linq;

namespace MediaProva.Integration.Tests.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoIntegrationTests
    {
        MediaProvaContext _context;
        AvaliacaoRepository _avaliacaoRepositorio;
        AvaliacaoService _servico;
        Avaliacao _avaliacao;
        Aluno _aluno;
        Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _context = new MediaProvaContext();
            _avaliacaoRepositorio = new AvaliacaoRepository(_context);
            _servico = new AvaliacaoService(_avaliacaoRepositorio);
            _avaliacao = AvaliacaoObjectMother.CriarAvaliacaoValida();
            _aluno = AlunoObjectMother.CriarAlunoValido();
            _resultado = ResultadoObjectMother.CriarResultadoValido(_aluno, _avaliacao);
            Database.SetInitializer(new BaseSqlTest());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Teste_Avaliacao_Integracao_Add_Deve_Inserir_Avaliacao()
        {
            //Cenario
            _avaliacao.Resultados.Add(_resultado);

            //Acao
            _avaliacao = _servico.Add(_avaliacao);

            //Verificacao
            _avaliacao.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Avaliacao_Integracao_Get_Deve_Obter_Avaliacao_PorId()
        {
            //Cenario
            _avaliacao.Resultados.Add(_resultado);
            _avaliacao = _servico.Add(_avaliacao);

            //Acao
            var avaliacaoObtido = _servico.Get(_avaliacao.Id);

            //Verificacao
            avaliacaoObtido.Id.Should().Be(_avaliacao.Id);
        }

        [Test]
        public void Teste_Avaliacao_Integracao_GetAll_Deve_Obter_Todos_Avaliacaos()
        {
            //Cenario
            _avaliacao.Id = 1;

            //Acao
            var avaliacaos = _servico.GetAll();

            //Verificacao
            avaliacaos.Count().Should().BeGreaterThan(0);
            avaliacaos.First().Id.Should().Be(_avaliacao.Id);
        }

        [Test]
        public void Teste_Avaliacao_Integracao_Delete_Deve_Deletar_Avaliacao()
        {
            //Cenario
            _avaliacao = _avaliacaoRepositorio.Add(_avaliacao);

            //Acao
            _servico.Delete(_avaliacao);
            var avaliacaoExcluido = _servico.Get(_avaliacao.Id);

            //Verificacao
            avaliacaoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Avaliacao_Integracao_Update_Deve_Atualizar_Avaliacao()
        {
            //Cenario
            _avaliacao.Resultados.Add(_resultado);
            _avaliacao = _servico.Add(_avaliacao);
            _avaliacao.Assunto = "atualizado";

            //Acao
            var avaliacaoAtualizado = _servico.Update(_avaliacao);

            //Verificacao
            avaliacaoAtualizado.Assunto.Should().Be(_avaliacao.Assunto);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        public void Teste_Avaliacao_Integracao_Delete_Deve_Lancar_IsTiedException()
        {
            //Cenario
            _avaliacao.Resultados.Add(_resultado);
            _avaliacao = _servico.Add(_avaliacao);

            //Acao
            Action action = () => _servico.Delete(_avaliacao);

            //Verificacao
            action.Should().Throw<IsTiedException>();
        }
    }
}
