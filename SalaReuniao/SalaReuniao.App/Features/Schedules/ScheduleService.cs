using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;
using SalaReuniao.Domain.Features.Schedules;
using SalaReuniao.Features.Rooms;
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

            if (IsOkToAdd(entity))
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

        public Room GetRoomFromSchedule(int id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _scheduleRepository.GetRoomFromSchedule(id);
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

            if (IsOkToUpdate(entity))
                throw new DateBookedException();

            return _scheduleRepository.Update(entity);
        }

        private bool IsOkToAdd(Schedule entity)
        {
            var bookingTime = _scheduleRepository.GetEndingTime(entity.Room.Id);

            if (bookingTime != null && entity.Statirg < bookingTime.Ending)
                return true;

            return false;
        }

        private bool IsOkToUpdate(Schedule entity)
        {
            var bookingTime = _scheduleRepository.GetEndingTime(entity.Room.Id);
            var schedule = _scheduleRepository.GetByRoom(entity.Room.Id);

            if (entity.Statirg < bookingTime.Ending && schedule != null && schedule.Id != entity.Id)
                return true;

            return false;
        }
    }
}
