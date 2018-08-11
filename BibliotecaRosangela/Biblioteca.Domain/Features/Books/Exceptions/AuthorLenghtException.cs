using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class AuthorLenghtException : BusinessException
    {
        public AuthorLenghtException() : base("O AUTOR não pode conter menos que 4 caracteres!")
        {
        }
    }
}
