using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Loans.Exceptions
{
    public class CustomerLengthException : BusinessException
    {
        public CustomerLengthException() : base("O CLIENTE não pode conter menos que 4 caracteres!")
        {
        }
    }
}
