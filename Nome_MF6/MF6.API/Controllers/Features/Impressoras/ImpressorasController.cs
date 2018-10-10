using MF6.API.Controllers.Common;
using MF6.Application.Features.Impressoras;
using MF6.Domain.Features.Impressoras;
using MF6.Infra.ORM.Contexts;
using MF6.Infra.ORM.Features.Impressoras;
using System.Web.Http;

namespace MF6.API.Controllers.Features.Impressoras
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

        #region HttpGet

        [HttpGet]

        public IHttpActionResult Get()
        {
            var query = _impressoraService.GetAll();

            return HandleQueryable<Impressora>(query);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _impressoraService.GetById(id));
        }

        #endregion

        #region HttpPost

        [HttpPost]
        public IHttpActionResult Post(Impressora impressora)
        {
            return HandleCallback(() => _impressoraService.Add(impressora));
        }

        #endregion HttpPost

        #region HttpPut

        [HttpPut]
        public IHttpActionResult Update(Impressora impressora)
        {
            return HandleCallback(() => _impressoraService.Update(impressora));
        }

        #endregion

        #region HttpDelete

        [HttpDelete]
        public IHttpActionResult Delete(Impressora impressora)
        {
            return HandleCallback(() => _impressoraService.Remove(impressora));
        }

        #endregion HttpDelete

        #region PATCH

        [HttpPatch]
        [Route("nivel")]
        public IHttpActionResult AlmentarNivel(Nivelador nivelador)
        {
            return HandleCallback(() => _impressoraService.UpdateNivel(nivelador));
        }

        #endregion
    }
}