using Projeto_Prova_Tdd.Domain.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Auditions.Exceptions
{
    public class DuplicatedThemeException : BusinessException
    {
        public DuplicatedThemeException() : base("Este assunto já foi cadastrado!")
        {
        }
    }
}
