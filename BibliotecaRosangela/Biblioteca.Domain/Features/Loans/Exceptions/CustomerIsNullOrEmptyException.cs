using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Loans.Exceptions
{
    public class CustomerIsNullOrEmptyException : BusinessException
    {
        public CustomerIsNullOrEmptyException() : base("O CLIENTE não pode estar vazio!")
        {
        }
    }
}
