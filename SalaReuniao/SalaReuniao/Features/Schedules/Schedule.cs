using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Features.Schedules.Exceptions;
using SalaReuniao.Features.Utils;
using System;

namespace SalaReuniao.Domain.Features.Schedules
{
    public class Schedule : Entity
    {
        public DateTime Statirg { get; set; }
        public DateTime Ending { get; set; }
        public RoomTypes Room { get; set; }
        public int Chairs { get; set; }
        public Employee Employee { get; set; }
        public bool IsAvailable { get; set; }

        public override void Validate()
        {
            if (Statirg < DateTime.Today)
                throw new InvalidStartingTimeException();

            if (Ending < Statirg)
                throw new InvalidEndingTimeException();

            if (Employee == null)
                throw new NullEmployeeException();

            if (Chairs < 1)
                throw new ChairsNumberException();
        }
    }
}
