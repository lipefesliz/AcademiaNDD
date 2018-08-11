namespace ProjetoORM.Domain.Exceptions
{
    public class IsTiedException : BusinessException
    {
        public IsTiedException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
