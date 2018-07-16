using MediaProva.Domain.Exceptions;

namespace MediaProva.Domain.Features.Avaliacoes.Exceptions
{
    public class ResultadoVazioException : BusinessException
    {
        public ResultadoVazioException() : base("Voce precisa informar um resultado!")
        {
        }
    }
}
