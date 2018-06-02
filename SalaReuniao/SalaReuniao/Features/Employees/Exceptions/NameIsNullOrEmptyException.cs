using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Employees.Exceptions
{
    public class NameIsNullOrEmptyException : BusinessException
    {
        public NameIsNullOrEmptyException() : base("O NOME não pode estar vazio!")
        {
        }
    }
}
