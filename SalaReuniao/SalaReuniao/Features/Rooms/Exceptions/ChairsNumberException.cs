using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Rooms.Exceptions
{
    public class ChairsNumberException : BusinessException
    {
        public ChairsNumberException() : base("A quantidade de LUGARES não pode ser negativa!")
        {
        }
    }
}
