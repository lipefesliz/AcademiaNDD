using MediaProva.Domain.Exceptions;

namespace MediaProva.Domain.Features.Resultados.Exceptions
{
    public class AvaliacaoNulaException : BusinessException
    {
        public AvaliacaoNulaException() : base("Voce precisa informar uma avaliacao!")
        {
        }
    }
}
