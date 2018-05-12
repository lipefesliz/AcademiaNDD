using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class NameLenghtException : BusinessException
    {
        public NameLenghtException() : base("O NOME não pode conter menos que 4 caracteres!")
        {
        }
    }
}
