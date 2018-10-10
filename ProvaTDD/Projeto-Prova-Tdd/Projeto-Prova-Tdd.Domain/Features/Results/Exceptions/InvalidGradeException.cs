using Projeto_Prova_Tdd.Domain.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Results.Exceptions
{
    public class InvalidGradeException : BusinessException
    {
        public InvalidGradeException() : base("Você precisa selecionar uma nota!")
        {
        }
    }
}
