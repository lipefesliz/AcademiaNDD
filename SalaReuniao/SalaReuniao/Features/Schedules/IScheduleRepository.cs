using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Schedules;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Features.Schedules
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        bool IsBooked(string room);

        Schedule GetByRoom(string room);

        IList<string> GetAvailableRooms(DateTime bookingDate);
    }
}
