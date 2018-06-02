namespace SalaReuniao.Exceptions
{
    public class TiedException : BusinessException
    {
        public TiedException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
