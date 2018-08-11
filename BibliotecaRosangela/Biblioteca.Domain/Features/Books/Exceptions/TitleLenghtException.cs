using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class TitleLenghtException : BusinessException
    {
        public TitleLenghtException() : base("O TITULO não pode conter menos que 4 caracteres!")
        {
        }
    }
}
