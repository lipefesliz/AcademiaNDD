using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class AuthorIsNullOrEmptyException : BusinessException
    {
        public AuthorIsNullOrEmptyException() : base("O AUTOR não pode estar vazio!")
        {
        }
    }
}
