using MediaProva.Domain.Exceptions;

namespace MediaProva.Domain.Features.Avaliacoes.Exceptions
{
    public class AssuntoVazioException : BusinessException
    {
        public AssuntoVazioException() : base("Voce precisa informar um assunto!")
        {
        }
    }
}
