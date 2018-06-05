using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Schedules.Exceptions
{
    public class ChairsNumberException : BusinessException
    {
        public ChairsNumberException() : base("A quantidade de LUGARES não pode ser negativa!")
        {
        }
    }
}
