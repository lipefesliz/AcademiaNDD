using FluentAssertions;
using MF6.Common.Tests.Features.Impressoras;
using MF6.Domain.Features.Impressoras;
using MF6.Domain.Features.Toners;
using Moq;
using NUnit.Framework;

namespace MF6.Domain.Tests.Features.Impressoras
{
    [TestFixture]
    public class ImpressoraDomainTests
    {
        private Impressora _impressora;

        [SetUp]
        public void Initialize()
        {
            _impressora = ObjectMother.ObterImpressoraValida();
        }

        [Test]
        public void Impressora_Domain_DiminuirNivel_ShouldBeOk()
        {
            //Arrange
            var quantidade = 50;
            var nivel = _impressora.TonerColorido.Nivel - quantidade;

            //Action
            _impressora.TonerColorido.DiminuirNivel(quantidade);

            //Assert
            _impressora.TonerColorido.Nivel.Should().Be(nivel);
        }

        [Test]
        public void Impressora_Domain_AumentarNivel_ShouldBeOk()
        {
            //Arrange
            var quantidade = 50;
            _impressora.TonerColorido.Nivel = 50;
            var nivel = _impressora.TonerColorido.Nivel + quantidade;

            //Action
            _impressora.TonerColorido.AumentarNivel(quantidade);

            //Assert
            _impressora.TonerColorido.Nivel.Should().Be(nivel);
        }
    }
}
