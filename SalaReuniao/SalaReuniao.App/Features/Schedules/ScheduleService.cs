using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
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

            var bookingTime = _scheduleRepository.GetEndingTime(entity.Room.GetHashCode());

            if (bookingTime != null && entity.Statirg < bookingTime.Ending)
                throw new DateBookedException();

            return _scheduleRepository.Add(entity);
        }

        public void Delete(Schedule entity)
        {
            if (entity.Id < 1)
                throw new IdentifierUndefinedException();

            _scheduleRepository.Delete(entity.Id);
        }

        public Schedule Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _scheduleRepository.Get(id);
        }

        public IList<Schedule> GetAll()
        {
            return _scheduleRepository.GetAll();
        }

        public IList<Schedule> GetAvailableRooms(DateTime bookingDate)
        {
            return _scheduleRepository.GetAvailableRooms(bookingDate);
        }

        public Employee GetEmployeeFromSchedule(int id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _scheduleRepository.GetEmployeeFromSchedule(id);
        }

        public Schedule Update(Schedule entity)
        {
            if (entity.Id < 1)
                throw new IdentifierUndefinedException();

            entity.Validate();

            var bookingTime = _scheduleRepository.GetEndingTime(entity.Room.GetHashCode());
            var schedule = _scheduleRepository.GetByRoom(entity.Room.GetHashCode());

            if (entity.Statirg < bookingTime.Ending && schedule != null && schedule.Id != entity.Id)
                throw new DateBookedException();

            return _scheduleRepository.Update(entity);
        }
    }
}
