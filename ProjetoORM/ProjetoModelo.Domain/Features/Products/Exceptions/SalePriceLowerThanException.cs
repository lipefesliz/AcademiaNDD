using ProjetoORM.Domain.Exceptions;

namespace ProjetoORM.Domain.Features.Products
{
    public class SalePriceLowerThanException : BusinessException
    {
        public SalePriceLowerThanException() : base("O PREÇO DE VENDA deve ser maior que o PREÇO DE CUSTO!")
        {
        }
    }
}