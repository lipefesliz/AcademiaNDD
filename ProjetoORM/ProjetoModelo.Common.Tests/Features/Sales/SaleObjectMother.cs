using ProjetoORM.Common.Tests.Features.Products;
using ProjetoORM.Domain.Features.Products;
using ProjetoORM.Domain.Features.Sales;
using System.Collections.Generic;

namespace ProjetoORM.Common.Tests.Features.Sales
{
    public static class SaleObjectMother
    {
        private static Product product = ProductObjectMother.CreateValidProduct();

        public static Sale CreateValidSale()
        {
            return new Sale
            {
                Id = 1,
                Customer = "Zeca",
                Products = new List<Product>
                {
                    product
                },
                Amount = new List<int> { 3, 6 },
                Profit = 1000
            };
        }
    }
}
