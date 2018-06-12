using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Schedules.Exceptions
{
    public class NullEmployeeException : BusinessException
    {
        public NullEmployeeException() : base("Você precisa selecionar um FUNCIONÁRIO!")
        {
        }
    }
}
