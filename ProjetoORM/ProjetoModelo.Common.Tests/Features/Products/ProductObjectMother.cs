using ProjetoORM.Domain.Features.Products;
using System;

namespace ProjetoORM.Common.Tests.Features.Products
{
    public static class ProductObjectMother
    {
        public static Product CreateValidProduct()
        {
            return new Product
            {
                Id = 1,
                Name = "Creme",
                CostPrice = 50,
                SalePrice = 100,
                IsAvailable = true,
                Fabrication = DateTime.Now,
                Expiration = DateTime.Now.AddDays(30)
            };
        }
    }
}
