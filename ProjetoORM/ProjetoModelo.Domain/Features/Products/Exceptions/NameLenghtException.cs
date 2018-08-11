using ProjetoORM.Domain.Exceptions;

namespace ProjetoORM.Domain.Features.Products
{
    public class NameLenghtException : BusinessException
    {
        public NameLenghtException() : base("O NOME não pode conter menos que 4 caracteres!")
        {
        }
    }
}