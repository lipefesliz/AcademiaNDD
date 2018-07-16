using FluentAssertions;
using MediaProva.Common.Tests.Features.Avaliacoes;
using MediaProva.Domain.Features.Avaliacoes;
using NUnit.Framework;
using System;

namespace MediaProva.Domain.Tests.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoDomainTestes
    {
        Avaliacao _avaliacao;

        [SetUp]
        public void SetUp()
        {
            _avaliacao = AvaliacaoObjectMother.CriarAvaliacaoValida();
        }

        /*TESTES CAMINHO FELIZ*/
        //[Test]
        public void Teste_Avaliacao_Domain_Criar_Avaliacao_Nao_Deve_Jogar_Excecao()
        {
            Action action = _avaliacao.Validate;

            action.Should().NotThrow<Exception>();
        }
    }
}
