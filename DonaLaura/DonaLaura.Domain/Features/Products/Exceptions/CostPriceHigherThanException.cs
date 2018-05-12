using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class CostPriceHigherThanException : BusinessException
    {
        public CostPriceHigherThanException() : base("O PREÇO DE CUSTO não pode ser maior que o PREÇO DE VENDA!")
        {
        }
    }
}
