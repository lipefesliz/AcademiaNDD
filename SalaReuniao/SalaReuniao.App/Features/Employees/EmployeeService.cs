using System.Collections.Generic;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;

namespace SalaReuniao.App.Features.Employees
{
    public class EmployeeService : IService<Employee>
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Add(Employee entity)
        {
            entity.Validate();

            var employeeFounded = _employeeRepository.Exist(entity.Name);
            if (employeeFounded)
                throw new DuplicatedNameException();

            return _employeeRepository.Add(entity);
        }

        public void Delete(Employee entity)
        {
            if (entity.Id < 1)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(entity.Id))
                throw new TiedException();

            _employeeRepository.Delete(entity.Id);
        }

        public Employee Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _employeeRepository.Get(id);
        }

        public IList<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee Update(Employee entity)
        {
            if (entity.Id < 1)
                throw new IdentifierUndefinedException();

            entity.Validate();

            var employeeFounded = _employeeRepository.GetByName(entity.Name);
            if (employeeFounded != null)
            {
                if (employeeFounded.Id != entity.Id)
                    throw new DuplicatedNameException();
            }

            return _employeeRepository.Update(entity);
        }

        public bool IsTiedTo(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _employeeRepository.IsTiedTo(id);
        }
    }
}
