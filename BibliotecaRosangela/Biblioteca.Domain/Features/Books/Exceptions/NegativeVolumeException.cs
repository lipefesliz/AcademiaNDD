using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class NegativeVolumeException : BusinessException
    {
        public NegativeVolumeException() : base("O VOLUME não pode ser negativo!")
        {
        }
    }
}
