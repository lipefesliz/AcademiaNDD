namespace Projeto_Prova_Tdd.Domain.Exceptions
{
    public class DuplicatedNameException : BusinessException
    {
        public DuplicatedNameException() : base("Este nome já foi cadastrado!")
        {
        }
    }
}
