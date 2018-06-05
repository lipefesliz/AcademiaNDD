using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Features.Schedules
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        bool IsAvailable(int roomType);

        Schedule GetEndingTime(int roomType);

        Schedule GetByRoom(int roomType);

        IList<Schedule> GetAvailableRooms(DateTime starting);

        Employee GetEmployeeFromSchedule(int id);
    }
}
