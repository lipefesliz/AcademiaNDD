using MediaProva.Domain.Exceptions;

namespace MediaProva.Domain.Features.Alunos.Exceptions
{
    public class IdadeInvalidaException : BusinessException
    {
        public IdadeInvalidaException() : base("A idade precisa ser maior que zero!")
        {
        }
    }
}
