using BancoTabajara.Application.Features.Contas;
using BancoTabajara.Common.Tests.Features.Contas;
using BancoTabajara.Controllers.Features.Contass;
using BancoTabajara.Domain.Features.Contas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BancoTabajara.Controller.Tests.Features.Contas
{
    [TestFixture]
    public class ContaControllerTests
    {
        private ContasController _contaController;
        private Mock<IContaService> _contaServiceMock;
        private Mock<Conta> _conta;
        private Mock<Extrato> _extrato;
        private Mock<ModeloContaOperacoes> _contaOperacao;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _contaServiceMock = new Mock<IContaService>();
            _contaController = new ContasController()
            {
                Request = request,
                _contaService = _contaServiceMock.Object,
            };
            _conta = new Mock<Conta>();
        }

        #region GET

        [Test]
        public void Conta_Controller_Get_ShouldBeOk()
        {
            // Arrange
            var conta = ObjectMother.ObterContaValida();
            var response = new List<Conta>() { conta }.AsQueryable();
            _contaServiceMock.Setup(s => s.GetAll(null)).Returns(response);

            // Action
            IHttpActionResult callback = _contaController.Get();
            
            //Assert
            _contaServiceMock.Verify(s => s.GetAll(null), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Conta>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(conta.Id);
        }

        [Test]
        public void Conta_Controller_Get_Quantidade_ShouldBeOk()
        {
            // Arrange
            var quantidade = 1;
            _contaController.Request = new HttpRequestMessage(HttpMethod.Get,
                "http://localhost:55531/api/contas?quantidade=" + quantidade);
            var conta = ObjectMother.ObterContaValida();
            var response = new List<Conta>() { conta }.AsQueryable();
            _contaServiceMock.Setup(s => s.GetAll(quantidade)).Returns(response);

            // Action
            IHttpActionResult callback = _contaController.Get();
            
            //Assert
            _contaServiceMock.Verify(s => s.GetAll(quantidade), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Conta>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.Count.Should().Be(quantidade);
            httpResponse.Content.First().Id.Should().Be(conta.Id);
        }

        [Test]
        public void Conta_Controller_GetById_ShouldBeOk()
        {
            //Arrange
            var id = 1;
            _conta.Setup(c => c.Id).Returns(id);
            _contaServiceMock.Setup(c => c.GetById(id)).Returns(_conta.Object);

            //Action
            IHttpActionResult callback = _contaController.GetById(id);

            //Assert
            _contaServiceMock.Verify(c => c.GetById(id), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Conta>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _conta.Verify(c => c.Id, Times.Once);
        }

        [Test]
        public void Conta_Controller_GetExtratos_ShouldBeOk()
        {
            //Arrange
            _extrato = new Mock<Extrato>();
            List<Extrato> extratos = new List<Extrato>() { _extrato.Object };
            var id = 1;
            _contaServiceMock.Setup(c => c.GetExtratos(id)).Returns(extratos);

            //Action
            IHttpActionResult callback = _contaController.GetExtrato(id);

            //Assert
            _contaServiceMock.Verify(c => c.GetExtratos(id), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Extrato>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.Should().BeOfType<List<Extrato>>();
        }

        #endregion

        #region POST

        [Test]
        public void Conta_Controller_Post_ShouldBeOk()
        {
            //Arrange
            var id = 1;
            _contaServiceMock.Setup(c => c.Add(_conta.Object)).Returns(id);
            
            //Action
            IHttpActionResult callback = _contaController.Post(_conta.Object);

            //Assert
            _contaServiceMock.Verify(c => c.Add(_conta.Object), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
        }

        #endregion

        #region PUT

        [Test]
        public void Conta_Controller_Update_ShouldBeOk()
        {
            //Arrange
            var result = true;
            _contaServiceMock.Setup(c => c.Update(_conta.Object)).Returns(result);

            //Action
            IHttpActionResult callback = _contaController.Update(_conta.Object);

            //Assert
            _contaServiceMock.Verify(c => c.Update(_conta.Object), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
        }

        //[Test]
        public void Conta_Controller_Sacar_ShouldBeOk()
        {
            //Arrange
            _contaOperacao = new Mock<ModeloContaOperacoes>();
            var result = true;
            _contaServiceMock.Setup(c => c.Sacar(_contaOperacao.Object)).Returns(result);

            //Action
            IHttpActionResult callback = _contaController.Update(_conta.Object);

            //Assert
            _contaServiceMock.Verify(c => c.Update(_conta.Object), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
        }

        #endregion
    }
}
