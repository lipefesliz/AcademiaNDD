using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Features.Schedules.Exceptions;
using SalaReuniao.Features.Schedules.Utils;
using System;

namespace SalaReuniao.Domain.Features.Schedules
{
    public class Schedule : Entity
    {
        public DateTime BookingDate { get; set; }
        public RoomTypes Room { get; set; }
        public Employee Employee { get; set; }
        public bool IsAvailable { get; set; }

        public override void Validate()
        {
            if (BookingDate < DateTime.Today)
                throw new InvalidDateException();

            if (Employee == null)
                throw new NullEmployeeException();
        }
    }
}
