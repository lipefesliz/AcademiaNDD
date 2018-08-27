using AutoMapper;
using AutoMapper.QueryableExtensions;
using BancoTabajara.Application.Features.Contas;
using BancoTabajara.Application.Features.Contas.Commands;
using BancoTabajara.Application.Features.Contas.Queries;
using BancoTabajara.Application.Features.Contas.ViewModels;
using BancoTabajara.Controllers.Common;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Domain.Features.Movimentacoes;
using Microsoft.AspNet.OData.Query;
using Prova1.API.Filters;
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
        [Authorize]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Conta> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs().Where(x => x.Key.Equals("quantidade")).FirstOrDefault();

            ContaQuery query = null;

            if (queryString.Key != null)
            {
                query = new ContaQuery();
                query.Quantity = int.Parse(queryString.Value);
            }

            var result = _service.GetAll(query);
            return HandleQuery<Conta, ContaViewModel>(result, queryOptions);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var conta = _service.GetById(id);

            ContaViewModel contaViewModel = new ContaViewModel();

            contaViewModel = Mapper.Map<Conta, ContaViewModel>(conta);

            return HandleCallback(() => contaViewModel);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}/extrato")]
        public IHttpActionResult GetExtrato(int id)
        {
            return HandleCallback(() => _service.GetExtratos(id));
        }

        #endregion HttpGet

        #region HttpPost

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(ContaRegisterCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Add(cmd));
        }
        
        #endregion HttpPost

        #region HttpPut

        [HttpPut]
        [Authorize]
        public IHttpActionResult Update(ContaUpdateCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Update(cmd));
        }
        
        [HttpPut]
        [Authorize]
        [Route("sacar")]
        public IHttpActionResult Sacar(ContaTransacoesCommand cmd)
        {
            var validator = cmd.Validate(TipoMovimentacaoEnum.DEBITO);
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Sacar(cmd));
        }

        [HttpPut]
        [Authorize]
        [Route("depositar")]
        public IHttpActionResult Depositar(ContaTransacoesCommand cmd)
        {
            var validator = cmd.Validate(TipoMovimentacaoEnum.CREDITO);

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Depositar(cmd));
        }

        [HttpPut]
        [Authorize]
        [Route("transferir")]
        public IHttpActionResult Transferir(ContaTransacoesCommand cmd)
        {
            var validator = cmd.Validate(TipoMovimentacaoEnum.TRANSFERENCIA);

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Transferir(cmd));
        }

        #endregion HttpPut

        #region HttpDelete

        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(ContaRemoveCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Remove(cmd));
        }

        #endregion HttpDelete

        #region PATCH

        [HttpPatch]
        [Authorize]
        [Route("status")]
        public IHttpActionResult UpdateStatus(Conta conta)
        {
            return HandleCallback(() => _service.UpdateStatus(conta.Id));
        }

        #endregion
    }
}