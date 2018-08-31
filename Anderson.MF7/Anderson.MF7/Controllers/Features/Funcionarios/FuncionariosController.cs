using Anderson.MF7.Application.Features.Funcionarios;
using Anderson.MF7.Application.Features.Funcionarios.Commands;
using Anderson.MF7.Application.Features.Funcionarios.Queries;
using Anderson.MF7.Application.Features.Funcionarios.ViewModels;
using Anderson.MF7.Controllers.Common;
using Anderson.MF7.Domain.Features.Funcionarios;
using Anderson.MF7.Filters;
using AutoMapper;
using Microsoft.AspNet.OData.Query;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Anderson.MF7.Controllers.Features.Funcionarios
{
    [RoutePrefix("api/funcionarios")]
    public class FuncionariosController : ApiControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionariosController(IFuncionarioService service) : base()
        {
            _service = service;
        }

        #region HttpGet

        [HttpGet]
        [Authorize]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Funcionario> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs().Where(x => x.Key.Equals("quantidade")).FirstOrDefault();

            FuncionarioQuery query = null;

            if (queryString.Key != null)
            {
                query = new FuncionarioQuery();
                query.Quantity = int.Parse(queryString.Value);
            }

            var result = _service.GetAll(query);
            return HandleQuery<Funcionario, FuncionarioViewModel>(result, queryOptions);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var funcionario = _service.GetById(id);

            FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel();

            funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);

            return HandleCallback(() => funcionarioViewModel);
        }

        #endregion HttpGet

        #region HttpPost

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(FuncionarioRegisterCommand cmd)
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
        public IHttpActionResult Update(FuncionarioUpdateCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Update(cmd));
        }

        #endregion HttpPut

        #region HttpDelete

        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(FuncionarioRemoveCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _service.Remove(cmd));
        }

        #endregion HttpDelete
    }
}