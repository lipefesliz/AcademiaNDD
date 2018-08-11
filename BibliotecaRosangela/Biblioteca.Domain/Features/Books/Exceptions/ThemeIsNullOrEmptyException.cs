using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class ThemeIsNullOrEmptyException : BusinessException
    {
        public ThemeIsNullOrEmptyException() : base("O TEMA não pode estar vazio!")
        {
        }
    }
}
