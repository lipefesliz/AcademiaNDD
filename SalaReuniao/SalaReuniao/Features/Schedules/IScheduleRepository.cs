using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules.Utils;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Features.Schedules
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule IsAvailable(RoomTypes room);

        Schedule GetByRoom(RoomTypes room);

        IList<Schedule> GetAvailableRooms(DateTime bookingDate);

        Employee GetEmployeeFromSchedule(int id);
    }
}
