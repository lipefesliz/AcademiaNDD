using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Rooms;
using System;

namespace SalaReuniao.Common.Tests.Features.Schedules
{
    public partial class ScheduleObjectMother
    {
        public static Schedule CreateValidSchedule()
        {
            return new Schedule
            {
                Id = 1,
                Statirg = DateTime.Now,
                Ending = DateTime.Now.AddHours(2),
                Room = new Room { Id = 1},
                Employee = new Employee { Id = 1 },
                IsAvailable = true
            };
        }
    }
}
