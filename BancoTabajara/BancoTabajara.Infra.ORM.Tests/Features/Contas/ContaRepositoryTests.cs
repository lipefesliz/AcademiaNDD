using BancoTabajara.Common.Tests.Features.Contas;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Infra.ORM.Features.Contas;
using BancoTabajara.Infra.ORM.Tests.Context;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace BancoTabajara.Infra.ORM.Tests.Features.Contas
{
    [TestFixture]
    public class ContaRepositoryTests
    {
        private FakeDbContext _ctx;
        private ContaRepository _repository;
        private Conta _conta;
        private Conta _contaSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new ContaRepository(_ctx);
            _conta = ObjectMother.ObterContaValida();

            //Seed
            _contaSeed = ObjectMother.ObterContaValida();
            _ctx.Contas.Add(_contaSeed);
            _ctx.Clientes.Add(_contaSeed.Cliente);
            _ctx.Clientes.Add(_conta.Cliente);
            _ctx.SaveChanges();
        }

        #region ADD
        [Test]
        public void Contas_Repository_Add_ShouldBeOk()
        {
            //Action
            var contaAdicionada = _repository.Add(_conta);

            //Verify
            contaAdicionada.Should().NotBeNull();
            contaAdicionada.Id.Should().NotBe(0);
            var contaEsperada = _ctx.Contas.Find(contaAdicionada.Id);
            contaEsperada.Should().Be(contaAdicionada);
        }
        #endregion

        #region GET
        [Test]
        public void Contas_Repository_GetAll_ShouldBeOk()
        {
            //Action
            var contas = _repository.GetAll();

            //Verify
            contas.Should().NotBeNull();
            contas.Should().HaveCount(_ctx.Contas.Count());
            contas.First().Should().Be(_contaSeed);
        }

        [Test]
        public void Contas_Repository_GetById_ShouldBeOk()
        {
            //Action
            var contaEsperada = _repository.GetbyId(_contaSeed.Id);

            //Verify
            contaEsperada.Id.Should().NotBe(0);
            contaEsperada.Should().Be(_contaSeed);
        }

        #endregion

        #region REMOVE
        [Test]
        public void Contas_Repository_Remove_ShouldBeOk()
        {
            //Action
            var excluido = _repository.Remove(_contaSeed.Id);

            //Verify
            excluido.Should().BeTrue();
            _ctx.Contas.Where(c => c.Id == _contaSeed.Id).FirstOrDefault().Should().BeNull();
        }
        #endregion

        #region UPDATE
        [Test]
        public void Contas_Repository_Update_ShouldBeOk()
        {
            //Arrange
            var atualizado = false;
            var novoLimite = 1500;
            _contaSeed.Limite = novoLimite;

            //Action
            var action = new Action(() => { atualizado = _repository.Update(_contaSeed); });

            //Verify
            action.Should().NotThrow<Exception>();
            atualizado.Should().BeTrue();
        }
        #endregion
    }
}
