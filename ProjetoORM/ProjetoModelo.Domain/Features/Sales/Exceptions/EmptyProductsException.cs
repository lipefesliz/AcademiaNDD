using ProjetoORM.Domain.Exceptions;

namespace ProjetoORM.Domain.Features.Sales
{
    public class EmptyProductsException : BusinessException
    {
        public EmptyProductsException() : base("Deve ter produtos cadastrados!")
        {
        }
    }
}