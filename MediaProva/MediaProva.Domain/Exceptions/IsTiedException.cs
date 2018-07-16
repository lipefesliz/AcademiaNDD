namespace MediaProva.Domain.Exceptions
{
    public class IsTiedException : BusinessException
    {
        public IsTiedException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
