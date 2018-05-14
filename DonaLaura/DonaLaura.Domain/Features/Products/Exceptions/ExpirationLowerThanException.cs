using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class ExpirationLowerThanException : BusinessException
    {
        public ExpirationLowerThanException() : base("A DATA DE VALIDADE não pode ser menor que a DATA DE FABRICAÇÃO!")
        {
        }
    }
}
