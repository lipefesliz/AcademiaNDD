using System.Web.Http;

namespace BancoTabajara.Controllers.Common
{
    [RoutePrefix("api/public")]
    public class PublicController : ApiControllerBase
    {
        [HttpGet]
        [Route("is-alive")]
        public IHttpActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}