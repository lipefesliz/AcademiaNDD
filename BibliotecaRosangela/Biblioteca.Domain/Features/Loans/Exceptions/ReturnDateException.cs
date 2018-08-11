using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Features.Loans.Exceptions
{
    public class ReturnDateException : BusinessException
    {
        public ReturnDateException() : base("A DATA de DEVOLUCAO nao pode ser menor que a DATA de PUBLICACAO do livro!")
        {
        }
    }
}
