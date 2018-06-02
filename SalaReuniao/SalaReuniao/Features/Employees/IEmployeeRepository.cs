using SalaReuniao.Base;

namespace SalaReuniao.Features.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        bool Exist(string name);

        Employee GetByName(string name);

        bool IsTiedTo(long id);
    }
}
