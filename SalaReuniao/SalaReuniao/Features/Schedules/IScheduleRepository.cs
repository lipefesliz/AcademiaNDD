using SalaReuniao.Domain.Base;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules.Utils;
using System;
using System.Collections.Generic;

namespace SalaReuniao.Features.Schedules
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule IsBooked(RoomTypes room);

        Schedule GetByRoom(string room);

        IList<Schedule> GetAvailableRooms(DateTime bookingDate);
    }
}
