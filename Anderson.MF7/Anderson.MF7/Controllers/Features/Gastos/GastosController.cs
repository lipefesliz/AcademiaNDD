using Anderson.MF7.Application.Features.Gastos;
using Anderson.MF7.Application.Features.Gastos.Commands;
using Anderson.MF7.Application.Features.Gastos.Queries;
using Anderson.MF7.Application.Features.Gastos.ViewModels;
using Anderson.MF7.Controllers.Common;
using Anderson.MF7.Domain.Features.Gastos;
using Anderson.MF7.Filters;
using AutoMapper;
using Microsoft.AspNet.OData.Query;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Anderson.MF7.Controllers.Features.Gastos
{
    [RoutePrefix("api/gastos")]
    public class GastosController : ApiControllerBase
    {
        private readonly IGastoService _service;

        public GastosController(IGastoService service) : base()
        {
            _service = service;
        }

        #region HttpGet

        [HttpGet]
        [Authorize]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Gasto> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs().Where(x => x.Key.Equals("quantidade")).FirstOrDefault();

            GastoQuery query = null;

            if (queryString.Key != null)
            {
                query = new GastoQuery();
                query.Quantity = int.Parse(queryString.Value);
            }

            var result = _service.GetAll(query);
            return HandleQuery<Gasto, GastoViewModel>(result, queryOptions);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var gasto = _service.GetById(id);

            GastoViewModel gastoViewModel = new GastoViewModel();

            gastoViewModel = Mapper.Map<Gasto, GastoViewModel>(gasto);

            return HandleCallback(() => gastoViewModel);
        }

        #endregion HttpGet

        #region HttpPost

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(GastoRegisterCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Add(cmd));
        }

        #endregion HttpPost

        #region HttpDelete

        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(GastoRemoveCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Remove(cmd));
        }

        #endregion HttpDelete
    }
}