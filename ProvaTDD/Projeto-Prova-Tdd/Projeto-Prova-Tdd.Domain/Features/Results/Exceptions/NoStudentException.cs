using Projeto_Prova_Tdd.Domain.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Results.Exceptions
{
    public class NoStudentException : BusinessException
    {
        public NoStudentException() : base("Você precisa selecionar um aluno!")
        {
        }
    }
}
