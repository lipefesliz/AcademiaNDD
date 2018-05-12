using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class SalePriceNegativeException : BusinessException
    {
        public SalePriceNegativeException() : base("O PREÇO DE VENDA não pode ser negativo!")
        {
        }
    }
}
