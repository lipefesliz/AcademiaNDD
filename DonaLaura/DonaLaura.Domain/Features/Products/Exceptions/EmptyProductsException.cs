using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products.Exceptions
{
    public class EmptyProductsException : BusinessException
    {
        public EmptyProductsException() : base("Deve ter produtos cadastrados!")
        {
        }
    }
}
