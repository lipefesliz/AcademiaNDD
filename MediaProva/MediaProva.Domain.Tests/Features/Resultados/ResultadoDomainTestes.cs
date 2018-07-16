using FluentAssertions;
using MediaProva.Common.Tests.Features.Resultados;
using MediaProva.Domain.Features.Resultados;
using NUnit.Framework;
using System;

namespace MediaProva.Domain.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoDomainTestes
    {
        Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _resultado = ResultadoObjectMother.CriarResultadoValido();
        }

        /*TESTES CAMINHO FELIZ*/
        //[Test]
        public void Teste_Resultado_Domain_Criar_Resultado_Nao_Deve_Jogar_Excecao()
        {
            Action action = _resultado.Validate;

            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Teste_Resultado_Domain_Atribuir_Resultado_Nao_Deve_Jogar_Excecao()
        {
            //Acao
            _resultado.AtribuirResultado();

            //Verificacao
            _resultado.Aluno.Resultados.Count.Should().BeGreaterThan(0);
        }
    }
}
