using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Products
{
    public class SalePriceLowerThanException : BusinessException
    {
        public SalePriceLowerThanException() : base("O PREÇO DE VENDA deve ser maior que o PREÇO DE CUSTO!")
        {
        }
    }
}
