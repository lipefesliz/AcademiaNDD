using AutoMapper;
using BancoTabajara.Application.Features.Contas;
using BancoTabajara.Application.Features.Contas.Commands;
using BancoTabajara.Application.Features.Contas.Queries;
using BancoTabajara.Application.Mapping;
using BancoTabajara.Common.Tests.Features.Contas;
using BancoTabajara.Domain.Exceptions;
using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Domain.Features.Movimentacoes;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Application.Tests.Features.Contas
{
    [TestFixture]
    public class ContaServiceTests
    {
        private IContaService _service;
        private Mock<IContaRepository> _contaRepositoryFake;
        private Mock<IClienteRepository> _clienteRepositoryFake;
        private Mock<IMovimentacaoRepository> _movimentacaoRepositoryFake;
        private Conta _conta;
        private ContaRegisterCommand _contaRegister;
        private ContaUpdateCommand _contaUpdate;
        private ContaRemoveCommand _contaRemove;


        [SetUp]
        public void Initialize()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            _conta = ObjectMother.ObterContaValida();
            _contaRegister = Mapper.Map<ContaRegisterCommand>(_conta);
            _contaUpdate = Mapper.Map<ContaUpdateCommand>(_conta);
            _contaRemove = Mapper.Map<ContaRemoveCommand>(_conta);
            _contaRepositoryFake = new Mock<IContaRepository>();
            _clienteRepositoryFake = new Mock<IClienteRepository>();
            _service = new ContaService(_contaRepositoryFake.Object, _clienteRepositoryFake.Object);
        }

        #region ADD

        [Test]
        public void Conta_Servie_Add_ShouldBeOk()
        {
            //Arrange
            _clienteRepositoryFake.Setup(cl => cl.GetbyId(_conta.Cliente.Id)).Returns(_conta.Cliente);
            _contaRepositoryFake.Setup(co => co.Add(_conta)).Returns(_conta);

            //Action
            var idNovaConta = _service.Add(_contaRegister);

            //Assert
            _contaRepositoryFake.Verify(co => co.Add(_conta), Times.Once);
            idNovaConta.Should().Be(_conta.Id);
        }

        [Test]
        public void Conta_Servie_Add_WithNoClient_ShouldThrow_NotFoundException()
        {
            //Arrange
            _clienteRepositoryFake.Setup(cl => cl.GetbyId(_conta.Cliente.Id)).Returns((Cliente)null);

            //Action
            Action action = () => { _service.Add(_contaRegister); };

            //Assert
            action.Should().Throw<NotFoundException>();
            _contaRepositoryFake.Verify(co => co.Add(_conta), Times.Never);
        }

        #endregion

        #region GET

        [Test]
        public void Conta_Service_GetById_ShouldBeOk()
        {
            //Arrange
            var contaId = 1;
            _contaRepositoryFake.Setup(c => c.GetbyId(contaId)).Returns(_conta);

            //Action
            var contaObtida = _service.GetById(contaId);

            //Assert
            contaObtida.Id.Should().Be(_conta.Id);
            contaObtida.Should().BeOfType<Conta>();
        }

        [Test]
        public void Conta_Service_GetAll_ShouldBeOk()
        {
            //Arrange
            var repositoryMockValue = new List<Conta>() { _conta }.AsQueryable();
            _contaRepositoryFake.Setup(c => c.GetAll(null)).Returns(repositoryMockValue);
            var contaQuery = new ContaQuery();
            contaQuery = null;

            //Action
            var contas = _service.GetAll(contaQuery);

            //Assert
            contas.First().Id.Should().Be(_conta.Id);
            contas.Count().Should().Be(repositoryMockValue.Count());
        }

        [Test]
        public void Conta_Service_GetExtratos_ShouldBeOk()
        {
            //Arrange
            _conta = ObjectMother.ObterContaComMovimentacao();
            var contaId = 1;
            _contaRepositoryFake.Setup(c => c.GetbyId(contaId)).Returns(_conta);

            //Action
            var extratos = _service.GetExtratos(contaId);

            //Assert
            _contaRepositoryFake.Verify(c => c.GetbyId(contaId), Times.Once);
            extratos.Count.Should().Be(_conta.Movimentacoes.Count);
        }

        #endregion

        #region UPDATE
        
        [Test]
        public void Conta_Service_Update_ShouldBeOk()
        {
            //Arrange
            var result = true;
            _contaRepositoryFake.Setup(c => c.GetbyId(_conta.Id)).Returns(_conta);
            _clienteRepositoryFake.Setup(cl => cl.GetbyId(_conta.Cliente.Id)).Returns(_conta.Cliente);
            var movimentacaoFake = new Movimentacao { Id = 1 };
            var repositoryMockValue = new List<Movimentacao>() { movimentacaoFake }.AsQueryable();
            _movimentacaoRepositoryFake.Setup(m => m.GetAll(null)).Returns(repositoryMockValue);
            _conta.Limite = 10;
            _contaRepositoryFake.Setup(c => c.Update(_conta)).Returns(result);

            //Action
            var newResult = _service.Update(_contaUpdate);

            //Assert
            newResult.Should().BeTrue();
            _contaRepositoryFake.Verify(c => c.GetbyId(_conta.Id), Times.Once);
            _clienteRepositoryFake.Verify(cl => cl.GetbyId(_conta.Cliente.Id), Times.Once);
            _movimentacaoRepositoryFake.Verify(m => m.GetAll(null), Times.Once);
        }

        [Test]
        public void Conta_Service_UpdateStatus_ShouldBeOk()
        {
            //Arrange
            var result = true;
            var contaId = 1;
            _contaRepositoryFake.Setup(c => c.GetbyId(contaId)).Returns(_conta);
            _contaRepositoryFake.Setup(c => c.Update(_conta)).Returns(result);

            //Action
            var newResult = _service.UpdateStatus(contaId);

            //Assert
            _conta.Ativada.Should().BeFalse();
            _contaRepositoryFake.Verify(c => c.GetbyId(contaId), Times.Once);
        }

        [Test]
        public void Conta_Service_Sacar_ShouldBeOk()
        {
            //Arrange
            _conta = ObjectMother.ObterContaComMovimentacao();
            var valorSaque = 50;
            var contaOperacoes = new ContaTransacoesCommand() { ContaOrigemId = 1, Valor = valorSaque};
            var saldoFinal = _conta.SaldoTotal - valorSaque;
            var result = true;
            _contaRepositoryFake.Setup(c => c.GetbyId(contaOperacoes.ContaOrigemId)).Returns(_conta);
            _movimentacaoRepositoryFake.Setup(m => m.Add(_conta.Movimentacoes.Last())).Returns(_conta.Movimentacoes.Last());
            _contaRepositoryFake.Setup(c => c.Update(_conta)).Returns(result);

            //Action
            var newResult = _service.Sacar(contaOperacoes);

            //Assert
            newResult.Should().BeTrue();
            _conta.SaldoTotal.Should().Be(saldoFinal);
            _conta.Movimentacoes.Last().Tipo.Should().Be(TipoMovimentacaoEnum.DEBITO);
        }

        [Test]
        public void Conta_Service_Depositar_ShouldBeOk()
        {
            //Arrange
            _conta = ObjectMother.ObterContaComMovimentacao();
            var valorDeposito = 50;
            var contaOperacoes = new ContaTransacoesCommand() { ContaOrigemId = 1, Valor = valorDeposito };
            var saldoFinal = _conta.SaldoTotal + valorDeposito;
            var result = true;
            _contaRepositoryFake.Setup(c => c.GetbyId(contaOperacoes.ContaOrigemId)).Returns(_conta);
            _movimentacaoRepositoryFake.Setup(m => m.Add(_conta.Movimentacoes.Last())).Returns(_conta.Movimentacoes.Last());
            _contaRepositoryFake.Setup(c => c.Update(_conta)).Returns(result);

            //Action
            var newResult = _service.Depositar(contaOperacoes);

            //Assert
            newResult.Should().BeTrue();
            _conta.SaldoTotal.Should().Be(saldoFinal);
            _conta.Movimentacoes.Last().Tipo.Should().Be(TipoMovimentacaoEnum.CREDITO);
        }

        [Test]
        public void Conta_Service_Transferir_ShouldBeOk()
        {
            //Arrange
            var valorTransferencia = 50;
            _conta = ObjectMother.ObterContaComMovimentacao();
            var contaDestino = new Conta() { Id = 2, Ativada = true };
            contaDestino.Movimentacoes.Add(new Movimentacao { Tipo = TipoMovimentacaoEnum.CREDITO, Valor = valorTransferencia });
            var contaOperacoes = new ContaTransacoesCommand() { ContaOrigemId = 1, ContaDestinoId = 2, Valor = valorTransferencia };
            var saldoContaOrigem = _conta.SaldoTotal - valorTransferencia;
            var saldoContaDestino = contaDestino.SaldoTotal + valorTransferencia;
            var result = true;
            _contaRepositoryFake.Setup(c => c.GetbyId(contaOperacoes.ContaOrigemId)).Returns(_conta);
            _contaRepositoryFake.Setup(c => c.GetbyId(contaOperacoes.ContaDestinoId)).Returns(contaDestino);
            _movimentacaoRepositoryFake.Setup(m => m.Add(_conta.Movimentacoes.Last())).Returns(_conta.Movimentacoes.Last());
            _movimentacaoRepositoryFake.Setup(m => m.Add(contaDestino.Movimentacoes.Last())).Returns(contaDestino.Movimentacoes.Last());
            _contaRepositoryFake.Setup(c => c.Update(contaDestino)).Returns(result);
            _contaRepositoryFake.Setup(c => c.Update(_conta)).Returns(result);

            //Action
            var newResult = _service.Transferir(contaOperacoes);

            //Assert
            newResult.Should().BeTrue();
            _conta.SaldoTotal.Should().Be(saldoContaOrigem);
            contaDestino.SaldoTotal.Should().Be(saldoContaDestino);
            _conta.Movimentacoes.Last().Tipo.Should().Be(TipoMovimentacaoEnum.DEBITO);
            contaDestino.Movimentacoes.Last().Tipo.Should().Be(TipoMovimentacaoEnum.CREDITO);
        }

        #endregion

        #region REMOVE

        [Test]
        public void Conta_Service_Remove_ShouldBeOk()
        {
            //Arrange
            var result = true;
            _contaRepositoryFake.Setup(c => c.Remove(_conta.Id)).Returns(result);

            //Action
            var newResult = _service.Remove(_contaRemove);
            
            //Assert
            newResult.Should().BeTrue();
        }

        #endregion
    }
}
