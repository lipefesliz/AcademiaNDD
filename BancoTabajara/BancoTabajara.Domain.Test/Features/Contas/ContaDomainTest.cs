using BancoTabajara.Common.Tests.Features.Contas;
using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Domain.Features.Contas.Exceptions;
using BancoTabajara.Domain.Features.Movimentacoes;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace BancoTabajara.Domain.Tests.Features.Contas
{
    [TestFixture]
    public class ContaDomainTest
    {
        private Conta _conta;
        private Mock<Cliente> _cliente;

        [SetUp]
        public void Initialize()
        {
            _cliente = new Mock<Cliente>();
            _conta = ObjectMother.ObterConta(_cliente.Object);
        }

        [Test]
        public void Contas_Domain_Sacar_ShouldBeOk()
        {
            //Arrange
            var valor = 100;
            var novoSaldo = _conta.SaldoTotal - valor;
            var movimentacoes = 1;
            var debito = TipoMovimentacaoEnum.DEBITO;

            //Action
            _conta.Sacar(valor);

            //Assert
            _conta.SaldoTotal.Should().Be(novoSaldo);
            _conta.Movimentacoes.Count.Should().Be(movimentacoes);
            _conta.Movimentacoes.Last().Tipo.Should().Be(debito);
        }

        [Test]
        public void Contas_Domain_Depositar_ShouldBeOk()
        {
            //Arrange
            var valor = 100;
            var novoSaldo = _conta.SaldoTotal + valor;
            var movimentacoes = 1;
            var credito = TipoMovimentacaoEnum.CREDITO;

            //Action
            _conta.Depositar(valor);

            //Assert
            _conta.SaldoTotal.Should().Be(novoSaldo);
            _conta.Movimentacoes.Count.Should().Be(movimentacoes);
            _conta.Movimentacoes.Last().Tipo.Should().Be(credito);
        }

        [Test]
        public void Contas_Domain_Transferir_ShouldBeOk()
        {
            //Arrange
            var valor = 100;
            var novoSaldo = _conta.SaldoTotal - valor;
            var movimentacoes = 1;
            var debito = TipoMovimentacaoEnum.DEBITO;

            var contaDestino = ObjectMother.ObterConta(_cliente.Object);
            var novoSaldoContaDestino = contaDestino.SaldoTotal + valor;
            var credito = TipoMovimentacaoEnum.CREDITO;

            //Action
            _conta.Transferir(valor, contaDestino);

            //Assert
            _conta.SaldoTotal.Should().Be(novoSaldo);
            _conta.Movimentacoes.Count.Should().Be(movimentacoes);
            _conta.Movimentacoes.Last().Tipo.Should().Be(debito);
            contaDestino.SaldoTotal.Should().Be(novoSaldoContaDestino);
            contaDestino.Movimentacoes.Count.Should().Be(movimentacoes);
            contaDestino.Movimentacoes.Last().Tipo.Should().Be(credito);
        }

        /* TESTES ALTERNATIVOS */
        [Test]
        public void Contas_Domain_Sacar_ShouldThrow_ContaDesativadaException()
        {
            //Arrange
            var valor = 100;
            _conta = ObjectMother.ObterContaInativa();

            //Action
            Action action = () => _conta.Sacar(valor);

            //Assert
            action.Should().Throw<ContaDesativadaException>();
        }

        [Test]
        public void Contas_Domain_Sacar_ShouldThrow_SaldoInsuficienteException()
        {
            //Arrange
            var valor = _conta.SaldoTotal + 1;

            //Action
            Action action = () => _conta.Sacar(valor);

            //Assert
            action.Should().Throw<SaldoInsuficienteException>();
        }

        [Test]
        public void Contas_Domain_Depositar_ShouldThrow_ContaDesativadaException()
        {
            //Arrange
            var valor = 100;
            _conta = ObjectMother.ObterContaInativa();

            //Action
            Action action = () => _conta.Depositar(valor);

            //Assert
            action.Should().Throw<ContaDesativadaException>();
        }

        [Test]
        public void Contas_Domain_Transferir_ShouldThrow_ContaDesativadaException()
        {
            //Arrange
            var valor = 100;
            _conta = ObjectMother.ObterContaInativa();
            var contaDestino = ObjectMother.ObterConta(_cliente.Object);

            //Action
            Action action = () => _conta.Transferir(valor, contaDestino);

            //Assert
            action.Should().Throw<ContaDesativadaException>();
        }

        [Test]
        public void Contas_Domain_Transferir_para_ContaInvalida_ShouldThrow_ContaDesativadaException()
        {
            //Arrange
            var valor = 100;
            _conta = ObjectMother.ObterContaInativa();
            var contaDestino = ObjectMother.ObterConta(_cliente.Object);
            contaDestino.Ativada = false;

            //Action
            Action action = () => _conta.Transferir(valor, contaDestino);

            //Assert
            action.Should().Throw<ContaDesativadaException>();
        }

        [Test]
        public void Contas_Domain_Transferir_ShouldThrow_SaldoInsuficienteException()
        {
            //Arrange
            var valor = _conta.SaldoTotal + 1;
            var contaDestino = ObjectMother.ObterConta(_cliente.Object);

            //Action
            Action action = () => _conta.Transferir(valor, contaDestino);

            //Assert
            action.Should().Throw<SaldoInsuficienteException>();
        }
    }
}
