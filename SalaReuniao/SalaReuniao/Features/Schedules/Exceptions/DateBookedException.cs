using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Schedules.Exceptions
{
    public class DateBookedException : BusinessException
    {
        public DateBookedException() : base("Data já reservada!")
        {
        }
    }
}
