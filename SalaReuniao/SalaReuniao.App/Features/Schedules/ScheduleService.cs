using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Schedules;
using SalaReuniao.Features.Schedules.Exceptions;
using System;
using System.Collections.Generic;

namespace SalaReuniao.App.Features.Schedules
{
    public class ScheduleService : IService<Schedule>
    {
        private IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Schedule Add(Schedule entity)
        {
            entity.Validate();

            var result = _scheduleRepository.IsBooked(entity.Room.ToString());

            if (result)
                throw new DateBookedException();

            return _scheduleRepository.Add(entity);
        }

        public void Delete(Schedule entity)
        {
            if (entity.Id <= 0)
                throw new IdentifierUndefinedException();

            _scheduleRepository.Delete(entity.Id);
        }

        public Schedule Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _scheduleRepository.Get(id);
        }

        public IList<Schedule> GetAll()
        {
            return _scheduleRepository.GetAll();
        }

        public IList<string> GetAvailableRooms(DateTime bookingDate)
        {
            return _scheduleRepository.GetAvailableRooms(bookingDate);
        }

        public Schedule Update(Schedule entity)
        {
            if (entity.Id <= 0)
                throw new IdentifierUndefinedException();

            entity.Validate();

            var result = _scheduleRepository.IsBooked(entity.Room.ToString());
            var schedule = _scheduleRepository.GetByRoom(entity.Room.ToString());

            if (result && schedule.Id != entity.Id)
                throw new DateBookedException();

            return _scheduleRepository.Update(entity);
        }
    }
}
