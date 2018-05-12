namespace DonaLaura.Domain.Exceptions
{
    public class UnsupportedOperationException : BusinessException
    {
        public UnsupportedOperationException() : base("Operação não suportada!")
        {
        }
    }
}
