using MediaProva.Domain.Exceptions;

namespace MediaProva.Domain.Features.Alunos.Exceptions
{
    public class NomeVazioException : BusinessException
    {
        public NomeVazioException() : base("Voce precisa informar um nome!")
        {
        }
    }
}
