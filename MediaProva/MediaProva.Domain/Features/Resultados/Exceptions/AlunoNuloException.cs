using MediaProva.Domain.Exceptions;

namespace MediaProva.Domain.Features.Resultados.Exceptions
{
    public class AlunoNuloException : BusinessException
    {
        public AlunoNuloException() : base("Voce precisa informar um aluno!")
        {
        }
    }
}
