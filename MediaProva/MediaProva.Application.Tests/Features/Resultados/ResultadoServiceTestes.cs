using FluentAssertions;
using MediaProva.Application.Resultados;
using MediaProva.Common.Tests.Features.Resultados;
using MediaProva.Domain.Features.Resultados;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaProva.Application.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoServiceTestes
    {
        Mock<IResultadoRepository> _mockRepositorio;
        ResultadoService _servico;
        Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _mockRepositorio = new Mock<IResultadoRepository>();
            _servico = new ResultadoService(_mockRepositorio.Object);
            _resultado = ResultadoObjectMother.CriarResultadoValido();
        }

        [Test]
        public void Resultado_Aplicacao_Add_Deve_Adicionar_Resultado()
        {
            //cenario
            _resultado.Id = 1;
            _mockRepositorio.Setup(r => r.Add(_resultado)).Returns(_resultado);

            //acao
            var resultadoAdicionado = _servico.Add(_resultado);

            //verificar
            resultadoAdicionado.Id.Should().Be(_resultado.Id);
            _mockRepositorio.Verify(r => r.Add(_resultado));
        }

        [Test]
        public void Resultado_Aplicacao_Get_Deve_Obter_Resultado()
        {
            //cenario
            _resultado.Id = 1;
            _mockRepositorio.Setup(r => r.Get(_resultado.Id)).Returns(_resultado);

            //acao
            var resultadoObtido = _servico.Get(_resultado.Id);

            //verificar
            resultadoObtido.Id.Should().Be(_resultado.Id);
            _mockRepositorio.Verify(r => r.Get(_resultado.Id));
        }

        [Test]
        public void Resultado_Aplicacao_GetAll_Deve_Obter_Todos_Resultados()
        {
            //cenario
            _mockRepositorio.Setup(r => r.GetAll()).Returns(new List<Resultado> { _resultado });

            //acao
            var resultados = _servico.GetAll();

            //verificar
            resultados.First().Should().Equals(_resultado);
            _mockRepositorio.Verify(r => r.GetAll());
        }

        [Test]
        public void Resultado_Aplicacao_Delete_Deve_Excluir_Resultado()
        {
            //cenario
            _resultado.Id = 1;
            _mockRepositorio.Setup(r => r.Delete(_resultado));

            //acao
            Action action = () => _servico.Delete(_resultado);

            //verificar
            action.Should().NotThrow<Exception>();
            _mockRepositorio.Verify(r => r.Delete(_resultado));
        }

        [Test]
        public void Resultado_Aplicacao_Update_Deve_Atualizar_Resultado()
        {
            //cenario
            _resultado.Id = 1;
            _resultado.Nota = 5;
            _mockRepositorio.Setup(r => r.Update(_resultado)).Returns(_resultado);

            //acao
            var resultadoAtualizada = _servico.Update(_resultado);

            //verificar
            resultadoAtualizada.Nota.Should().Be(_resultado.Nota);
            _mockRepositorio.Verify(r => r.Update(_resultado));
        }

        /* TESTES ALTERNATIVOS */
    }
}
