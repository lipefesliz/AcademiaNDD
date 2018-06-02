using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Schedules.Exceptions
{
    public class InvalidDateException : BusinessException
    {
        public InvalidDateException() : base("A DATA não pode ser aterior a data atual!")
        {
        }
    }
}
