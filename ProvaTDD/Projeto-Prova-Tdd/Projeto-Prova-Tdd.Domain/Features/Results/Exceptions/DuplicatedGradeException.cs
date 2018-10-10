using Projeto_Prova_Tdd.Domain.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Results.Exceptions
{
    public class DuplicatedGradeException : BusinessException
    {
        public DuplicatedGradeException() : base("Este aluno já possui uma nota para esta avaliação!")
        {
        }
    }
}
