namespace Biblioteca.Domain.Exceptions
{
    public class ItemTiedToException : BusinessException
    {
        public ItemTiedToException() : base("Este registro possui depêndecias!")
        {
        }
    }
}
