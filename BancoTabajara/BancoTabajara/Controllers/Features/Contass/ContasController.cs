using BancoTabajara.Application.Features.Contas;
using BancoTabajara.Controllers.Common;
using BancoTabajara.Domain.Features.Contas;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BancoTabajara.Controllers.Features.Contass
{
    [RoutePrefix("api/contas")]
    public class ContasController : ApiControllerBase
    {
        private readonly IContaService _service;

        public ContasController(IContaService service) : base()
        {
            _service = service;
        }

        #region HttpGet

        [HttpGet]
        public IHttpActionResult Get()
        {
            var queryString = Request.GetQueryNameValuePairs().Where(x => x.Key.Equals("quantidade")).FirstOrDefault();

            int? quantidade = null;
            if (queryString.Key != null)
                quantidade = int.Parse(queryString.Value);

            var query = _service.GetAll(quantidade);
            return HandleQueryable<Conta>(query);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _service.GetById(id));
        }

        [HttpGet]
        [Route("{id:int}/extrato")]
        public IHttpActionResult GetExtrato(int id)
        {
            return HandleCallback(() => _service.GetExtratos(id));
        }

        #endregion HttpGet

        #region HttpPost

        [HttpPost]
        public IHttpActionResult Post(Conta conta)
        {
            return HandleCallback(() => _service.Add(conta));
        }
        
        #endregion HttpPost

        #region HttpPut

        [HttpPut]
        public IHttpActionResult Update(Conta conta)
        {
            return HandleCallback(() => _service.Update(conta));
        }
        
        [HttpPut]
        [Route("sacar")]
        public IHttpActionResult Sacar(ModeloContaOperacoes modelo)
        {
            return HandleCallback(() => _service.Sacar(modelo));
        }

        [HttpPut]
        [Route("depositar")]
        public IHttpActionResult Depositar(ModeloContaOperacoes modelo)
        {
            return HandleCallback(() => _service.Depositar(modelo));
        }

        [HttpPut]
        [Route("transferir")]
        public IHttpActionResult Transferir(ModeloContaOperacoes modelo)
        {
            return HandleCallback(() => _service.Transferir(modelo));
        }

        #endregion HttpPut

        #region HttpDelete

        [HttpDelete]
        public IHttpActionResult Delete(Conta conta)
        {
            return HandleCallback(() => _service.Remove(conta));
        }

        #endregion HttpDelete

        #region PATCH

        [HttpPatch]
        [Route("status")]
        public IHttpActionResult UpdateStatus(Conta conta)
        {
            return HandleCallback(() => _service.UpdateStatus(conta.Id));
        }

        #endregion
    }
}