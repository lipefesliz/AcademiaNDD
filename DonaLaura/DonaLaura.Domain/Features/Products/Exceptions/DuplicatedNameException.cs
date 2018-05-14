using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products.Exceptions
{
    public class DuplicatedNameException : BusinessException
    {
        public DuplicatedNameException() : base("Este nome já foi cadastrado!")
        {
        }
    }
}
