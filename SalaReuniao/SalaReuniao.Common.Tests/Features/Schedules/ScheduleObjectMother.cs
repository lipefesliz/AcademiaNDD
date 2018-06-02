using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
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
                BookingDate = DateTime.Now,
                Room = Schedule.RoomType.Treinamento,
                Employee = new Employee { Id = 1 }
            };
        }
    }
}
