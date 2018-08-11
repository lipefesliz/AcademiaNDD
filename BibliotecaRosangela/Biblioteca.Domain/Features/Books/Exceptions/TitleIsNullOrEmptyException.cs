using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class TitleIsNullOrEmptyException : BusinessException
    {
        public TitleIsNullOrEmptyException() : base("O TITULO não pode estar vazio!")
        {
        }
    }
}
