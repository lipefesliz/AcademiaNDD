using Anderson.MF7.Controllers.Common;
using FluentAssertions;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Anderson.MF7.Controller.Tests.Common
{
    [TestFixture]
    public class PublicControllerTests
    {
        private PublicController _publicController;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _publicController = new PublicController()
            {
                Request = request
            };
        }

        #region GET

        [Test]
        public void Public_Controller_Get_ShouldOk()
        {
            // Action
            var callback = _publicController.IsAlive();

            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
        }

        #endregion
    }
}
