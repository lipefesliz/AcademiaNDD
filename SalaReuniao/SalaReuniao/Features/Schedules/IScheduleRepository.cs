using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Rooms;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Features.Schedules
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        bool IsAvailable(int id);

        Schedule GetEndingTime(int id);

        Schedule GetByRoom(int id);

        IList<Schedule> GetAvailableRooms(DateTime starting);

        Room GetRoomFromSchedule(int id);

        Employee GetEmployeeFromSchedule(int id);
    }
}
