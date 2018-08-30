using FluentAssertions;
using MF6.Domain.Features.Toners;
using NUnit.Framework;

namespace MF6.Domain.Tests.Features.Toners
{
    [TestFixture]
    public class TonerDomainTests
    {
        private Toner _toner;

        [SetUp]
        public void Initialize()
        {
            _toner = new Toner();
        }

        [Test]
        public void Toner_Domain_DiminuirNivel_ShouldBeOk()
        {
            //Arrange
            var quantidade = 50;
            var nivel = _toner.Nivel - quantidade;

            //Action
            _toner.DiminuirNivel(quantidade);

            //Assert
            _toner.Nivel.Should().Be(nivel);
        }

        [Test]
        public void Toner_Domain_AumentarNivel_ShouldBeOk()
        {
            //Arrange
            var quantidade = 50;
            _toner.Nivel = 50;
            var nivel = _toner.Nivel + quantidade;

            //Action
            _toner.AumentarNivel(quantidade);

            //Assert
            _toner.Nivel.Should().Be(nivel);
        }
    }
}
