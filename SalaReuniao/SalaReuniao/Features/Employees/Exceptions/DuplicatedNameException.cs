using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Employees.Exceptions
{
    public class DuplicatedNameException : BusinessException
    {
        public DuplicatedNameException() : base("Este nome já foi cadastrado!")
        {
        }
    }
}
