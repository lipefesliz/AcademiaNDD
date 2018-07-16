using FluentAssertions;
using MediaProva.Application.Avaliacoes;
using MediaProva.Common.Tests.Features.Avaliacoes;
using MediaProva.Domain.Exceptions;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Domain.Features.Resultados;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaProva.Application.Tests.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoServiceTestes
    {
        Mock<IAvaliacaoRepository> _mockRepositorio;
        AvaliacaoService _servico;
        Avaliacao _avaliacao;

        [SetUp]
        public void SetUp()
        {
            _mockRepositorio = new Mock<IAvaliacaoRepository>();
            _servico = new AvaliacaoService(_mockRepositorio.Object);
            _avaliacao = AvaliacaoObjectMother.CriarAvaliacaoValidaComResultado();
        }

        [Test]
        public void Avaliacao_Aplicacao_Add_Deve_Adicionar_Avaliacao()
        {
            //cenario
            _avaliacao.Id = 1;
            _mockRepositorio.Setup(r => r.Add(_avaliacao)).Returns(_avaliacao);

            //acao
            var avaliacaoAdicionado = _servico.Add(_avaliacao);

            //verificar
            avaliacaoAdicionado.Id.Should().Be(_avaliacao.Id);
            _mockRepositorio.Verify(r => r.Add(_avaliacao));
        }

        [Test]
        public void Avaliacao_Aplicacao_Get_Deve_Obter_Avaliacao()
        {
            //cenario
            _avaliacao.Id = 1;
            _mockRepositorio.Setup(r => r.Get(_avaliacao.Id)).Returns(_avaliacao);

            //acao
            var avaliacaoObtido = _servico.Get(_avaliacao.Id);

            //verificar
            avaliacaoObtido.Id.Should().Be(_avaliacao.Id);
            _mockRepositorio.Verify(r => r.Get(_avaliacao.Id));
        }

        [Test]
        public void Avaliacao_Aplicacao_GetAll_Deve_Obter_Todos_Avaliacaos()
        {
            //cenario
            _mockRepositorio.Setup(r => r.GetAll()).Returns(new List<Avaliacao> { _avaliacao });

            //acao
            var avaliacaos = _servico.GetAll();

            //verificar
            avaliacaos.First().Should().Equals(_avaliacao);
            _mockRepositorio.Verify(r => r.GetAll());
        }

        [Test]
        public void Avaliacao_Aplicacao_Delete_Deve_Excluir_Avaliacao()
        {
            //cenario
            _avaliacao.Id = 1;
            _avaliacao.Resultados = new List<Resultado>();
            _mockRepositorio.Setup(r => r.Delete(_avaliacao));

            //acao
            Action action = () => _servico.Delete(_avaliacao);

            //verificar
            action.Should().NotThrow<Exception>();
            _mockRepositorio.Verify(r => r.Delete(_avaliacao));
        }

        [Test]
        public void Avaliacao_Aplicacao_Update_Deve_Atualizar_Avaliacao()
        {
            //cenario
            _avaliacao.Id = 1;
            _avaliacao.Assunto= "atualizado";
            _mockRepositorio.Setup(r => r.Update(_avaliacao)).Returns(_avaliacao);

            //acao
            var avaliacaoAtualizada = _servico.Update(_avaliacao);

            //verificar
            avaliacaoAtualizada.Assunto.Should().Be(_avaliacao.Assunto);
            _mockRepositorio.Verify(r => r.Update(_avaliacao));
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        public void Avaliacao_Aplicacao_Delete_Deve_Lancar_()
        {
            //cenario
            _avaliacao.Id = 1;
            _mockRepositorio.Setup(r => r.Delete(_avaliacao));

            //acao
            Action action = () => _servico.Delete(_avaliacao);

            //verificar
            action.Should().Throw<IsTiedException>();
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
