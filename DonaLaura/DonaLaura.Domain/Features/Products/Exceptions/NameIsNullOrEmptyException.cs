using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class NameIsNullOrEmptyException : BusinessException
    {
        public NameIsNullOrEmptyException() : base("O NOME não pode estar vazio!")
        {
        }
    }
}
