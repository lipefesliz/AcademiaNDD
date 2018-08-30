using FluentAssertions;
using MF6.API.Controllers.Features.Impressoras;
using MF6.Application.Features.Impressoras;
using MF6.Common.Tests.Features.Impressoras;
using MF6.Domain.Features.Impressoras;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MF6.Controller.Tests.Features.Impressoras
{
    [TestFixture]
    public class ImpressoraControllerTests
    {
        private ImpressorasController _impressoraController;
        private Mock<IImpressoraService> _impressoraServiceMock;
        private Mock<Impressora> _impressora;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _impressoraServiceMock = new Mock<IImpressoraService>();
            _impressoraController = new ImpressorasController()
            {
                Request = request,
                _impressoraService = _impressoraServiceMock.Object,
            };
            _impressora = new Mock<Impressora>();
        }

        #region GET

        [Test]
        public void Impressora_Controller_Get_ShouldBeOk()
        {
            // Arrange
            var impressora = ObjectMother.ObterImpressoraValida();
            var response = new List<Impressora>() { impressora }.AsQueryable();
            _impressoraServiceMock.Setup(s => s.GetAll()).Returns(response);

            // Action
            IHttpActionResult callback = _impressoraController.Get();

            //Assert
            _impressoraServiceMock.Verify(s => s.GetAll(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Impressora>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(impressora.Id);
        }

        [Test]
        public void Impressora_Controller_GetById_ShouldBeOk()
        {
            //Arrange
            var id = 1;
            _impressora.Setup(c => c.Id).Returns(id);
            _impressoraServiceMock.Setup(c => c.GetById(id)).Returns(_impressora.Object);

            //Action
            IHttpActionResult callback = _impressoraController.GetById(id);

            //Assert
            _impressoraServiceMock.Verify(c => c.GetById(id), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Impressora>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _impressora.Verify(c => c.Id, Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Impressora_Controller_Post_ShouldBeOk()
        {
            //Arrange
            var id = 1;
            _impressoraServiceMock.Setup(c => c.Add(_impressora.Object)).Returns(id);

            //Action
            IHttpActionResult callback = _impressoraController.Post(_impressora.Object);

            //Assert
            _impressoraServiceMock.Verify(c => c.Add(_impressora.Object), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
        }

        #endregion

        #region PUT

        [Test]
        public void Impressora_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _impressoraServiceMock.Setup(c => c.Update(_impressora.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _impressoraController.Update(_impressora.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _impressoraServiceMock.Verify(s => s.Update(_impressora.Object), Times.Once);
        }

        #endregion

        #region DELETE

        [Test]
        public void Impressora_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _impressoraServiceMock.Setup(c => c.Remove(_impressora.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _impressoraController.Delete(_impressora.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _impressoraServiceMock.Verify(s => s.Remove(_impressora.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        #endregion
    }
}
