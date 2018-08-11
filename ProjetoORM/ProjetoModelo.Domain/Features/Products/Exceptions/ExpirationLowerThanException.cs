using ProjetoORM.Domain.Exceptions;

namespace ProjetoORM.Domain.Features.Products
{
    public class ExpirationLowerThanException : BusinessException
    {
        public ExpirationLowerThanException() : base("A DATA DE VALIDADE não pode ser menor ou igual a DATA DE FABRICAÇÃO!")
        {
        }
    }
}