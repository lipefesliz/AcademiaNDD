using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Schedules.Exceptions
{
    public class InvalidStartingTimeException : BusinessException
    {
        public InvalidStartingTimeException() : base("A DATA de INICIO não pode ser aterior a data atual!")
        {
        }
    }
}
