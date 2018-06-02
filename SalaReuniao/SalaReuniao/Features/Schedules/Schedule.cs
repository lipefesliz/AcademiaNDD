using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Features.Schedules.Exceptions;
using System;

namespace SalaReuniao.Domain.Features.Schedules
{
    public class Schedule : Entity
    {
        public enum RoomType { Treinamento, Reuniao, VideoConferencia}

        public DateTime BookingDate { get; set; }
        public RoomType Room { get; set; }
        public Employee Employee { get; set; }

        public override void Validate()
        {
            if (BookingDate < DateTime.Today)
                throw new InvalidDateException();

            if (Employee == null)
                throw new NullEmployeeException();
        }
    }
}
