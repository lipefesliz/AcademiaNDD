using Projeto_Prova_Tdd.Domain.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Auditions.Exceptions
{
    public class NoResultsException : BusinessException
    {
        public NoResultsException() : base("Você precisa informar as notas!")
        {
        }
    }
}
