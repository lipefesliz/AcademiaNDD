using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class CostPriceNegativeException : BusinessException
    {
        public CostPriceNegativeException() : base("O PREÇO DE CUSTO não pode ser negativo!")
        {
        }
    }
}
