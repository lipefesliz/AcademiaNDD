namespace Projeto_Prova_Tdd.Domain.Exceptions
{
    public class IdentifierUndefinedException : BusinessException
    {
        public IdentifierUndefinedException() : base("O ID não pode ser vazio!")
        {
        }
    }
}
