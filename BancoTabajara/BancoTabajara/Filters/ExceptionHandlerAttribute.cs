using BancoTabajara.Extensions;
using System.Web.Http.Filters;

namespace BancoTabajara.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.HandleExecutedContextException();
        }
    }
}