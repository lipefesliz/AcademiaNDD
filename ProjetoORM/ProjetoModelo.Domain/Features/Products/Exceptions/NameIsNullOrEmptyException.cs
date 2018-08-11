
using ProjetoORM.Domain.Exceptions;

namespace ProjetoORM.Domain.Features.Products
{
    public class NameIsNullOrEmptyException : BusinessException
    {
        public NameIsNullOrEmptyException() : base("O NOME não pode estar vazio!")
        {
        }
    }
}