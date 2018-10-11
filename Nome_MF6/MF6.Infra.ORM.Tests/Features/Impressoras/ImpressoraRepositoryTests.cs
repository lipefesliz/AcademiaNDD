using Effort;
using FluentAssertions;
using MF6.Common.Tests.Features.Impressoras;
using MF6.Domain.Features.Impressoras;
using MF6.Infra.ORM.Features.Impressoras;
using MF6.Infra.ORM.Tests.Contexts;
using NUnit.Framework;
using System;

namespace MF6.Infra.ORM.Tests.Features.Impressoras
{
    [TestFixture]
    public class ImpressoraRepositoryTests
    {
        private FakeDbContext _ctx;
        private ImpressoraRepository _repository;
        private Impressora _impressora;
        private Impressora _impressoraSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new ImpressoraRepository(_ctx);
            _impressora = ObjectMother.ObterImpressoraValida();

            //Seed
            _impressoraSeed = ObjectMother.ObterImpressoraValida();
            _ctx.Impressoras.Add(_impressoraSeed);
            _ctx.SaveChanges();
        }

        #region ADD

        [Test]
        public void Impressora_Repository_Add_ShouldBeOk()
        {
            //Action
            var impressoraAdicionada = _repository.Add(_impressora);

            //Verify
            impressoraAdicionada.Should().NotBeNull();
            impressoraAdicionada.Id.Should().NotBe(0);
            var impressoraEsperada = _ctx.Impressoras.Find(impressoraAdicionada.Id);
            impressoraEsperada.Should().Be(impressoraAdicionada);
        }

        [Test]
        public void Impressora_Repository_Add_NovaImpressora_ShouldBeOk()
        {
            //Arrange
            var imp = new Impressora();
            imp.Marca = "teste";
            imp.Rede = "teste";
            imp.EmUso = true;

            //Action
            var impressoraAdicionada = _repository.Add(imp);

            //Verify
            impressoraAdicionada.Should().NotBeNull();
            impressoraAdicionada.Id.Should().NotBe(0);
            var impressoraEsperada = _ctx.Impressoras.Find(impressoraAdicionada.Id);
            impressoraEsperada.Should().Be(impressoraAdicionada);
        }

        #endregion
    }
}
