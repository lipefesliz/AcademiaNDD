
using SalaReuniao.Domain.Features.Employees;

namespace SalaReuniao.Common.Tests.Features.Employees
{
    public static partial class EmployeeObjectMother
    {
        public static Employee CreateValidEmployee()
        {
            return new Employee
            {
                Id = 1,
                Name = "Juca",
                Post = "Desenvolvedor",
                BranchLine = 1
            };
        }
    }
}
