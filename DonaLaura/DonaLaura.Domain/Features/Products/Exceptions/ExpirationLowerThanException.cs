using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class DuplicateNameException : BusinessException
    {
        public DuplicateNameException() : base("A DATA DE VALIDADE não pode ser menor que a DATA DE FABRICAÇÃO!")
        {
        }
    }
}
