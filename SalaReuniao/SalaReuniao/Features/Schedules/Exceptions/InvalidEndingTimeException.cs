using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Schedules.Exceptions
{
    public class InvalidEndingTimeException : BusinessException
    {
        public InvalidEndingTimeException() : base("A DATA de TERMINO não pode ser aterior a DATA de INICIO!")
        {
        }
    }
}
