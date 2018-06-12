using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Schedules.Exceptions
{
    public class NullRoomException : BusinessException
    {
        public NullRoomException() : base("Você precisa selecionar uma SALA!")
        {
        }
    }
}
