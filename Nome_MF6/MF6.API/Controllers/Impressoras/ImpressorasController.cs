using MF6.API.Controllers.Common;
using MF6.Application.Features.Impressoras;
using MF6.Infra.ORM.Contexts;
using MF6.Infra.ORM.Features.Impressoras;
using System.Web.Http;

namespace MF6.API.Controllers.Impressoras
{
    [RoutePrefix("api/impressoras")]
    public class ImpressorasController : ApiControllerBase
    {
        public IImpressoraService _impressoraService;

        public ImpressorasController() : base()
        {
            var context = new MF6Context();
            var repository = new ImpressoraRepository(context);
            _impressoraService = new ImpressoraService(repository);
        }

        #region PATCH

        [HttpPatch]
        [Route("adicao")]
        public IHttpActionResult AumentarNivel(Nivelador nivelador)
        {
            return HandleCallback(() => _impressoraService.AumentarNivel(nivelador));
        }

        [HttpPatch]
        [Route("subtracao")]
        public IHttpActionResult DiminuirNivel(Nivelador nivelador)
        {
            return HandleCallback(() => _impressoraService.DiminuirNivel(nivelador));
        }

        #endregion
    }
}