using SalaReuniao.Exceptions;

namespace SalaReuniao.Features.Employees.Exceptions
{
    public class PostIsNullOrEmptyException : BusinessException
    {
        public PostIsNullOrEmptyException() : base("O CARGO não pode estar vazio!")
        {
        }
    }
}
