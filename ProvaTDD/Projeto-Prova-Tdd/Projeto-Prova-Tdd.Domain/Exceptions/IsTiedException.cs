namespace Projeto_Prova_Tdd.Domain.Exceptions
{
    public class IsTiedException : BusinessException
    {
        public IsTiedException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
