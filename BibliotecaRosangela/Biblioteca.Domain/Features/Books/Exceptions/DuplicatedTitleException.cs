using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Books.Exceptions
{
    public class DuplicatedTitleException : BusinessException
    {
        public DuplicatedTitleException() : base("Este titulo já foi cadastrado!")
        {
        }
    }
}
