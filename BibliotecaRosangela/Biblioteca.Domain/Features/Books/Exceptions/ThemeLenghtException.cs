using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class ThemeLenghtException : BusinessException
    {
        public ThemeLenghtException() : base("O TEMA não pode conter menos que 4 caracteres!")
        {
        }
    }
}
