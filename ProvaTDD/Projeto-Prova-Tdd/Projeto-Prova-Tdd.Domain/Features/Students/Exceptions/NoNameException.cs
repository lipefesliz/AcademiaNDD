using Projeto_Prova_Tdd.Domain.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Students.Exceptions
{
    public class NoNameException : BusinessException
    {
        public NoNameException() : base("Você precisa inserir um nome!")
        {
        }
    }
}
