using DonaLaura.Domain.Features.Products;
using System;

namespace DonaLaura.Common.Tests.Features.Products
{
    public static partial class ObjectMother
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

        public static Product CreateInvalidProductEmptyName()
        {
            return new Product
            {
                Id = 1,
                Name = "",
                CostPrice = 50,
                SalePrice = 100,
                IsAvailable = true,
                Fabrication = DateTime.Now,
                Expiration = DateTime.Now.AddDays(30)
            };
        }

        public static Product CreateInvalidProductLenghName()
        {
            return new Product
            {
                Id = 1,
                Name = "aaa",
                CostPrice = 50,
                SalePrice = 100,
                IsAvailable = true,
                Fabrication = DateTime.Now,
                Expiration = DateTime.Now.AddDays(30)
            };
        }

        public static Product CreateInvalidProductNegativeCostPrice()
        {
            return new Product
            {
                Id = 1,
                Name = "Creme",
                CostPrice = -50,
                SalePrice = 100,
                IsAvailable = true,
                Fabrication = DateTime.Now,
                Expiration = DateTime.Now.AddDays(30)
            };
        }

        public static Product CreateInvalidProductLowerThanSalePrice()
        {
            return new Product
            {
                Id = 1,
                Name = "Creme",
                CostPrice = 50,
                SalePrice = 50,
                IsAvailable = true,
                Fabrication = DateTime.Now,
                Expiration = DateTime.Now.AddDays(30)
            };
        }

        public static Product CreateInvalidProductExpirationLowerThan()
        {
            return new Product
            {
                Id = 1,
                Name = "Creme",
                CostPrice = 50,
                SalePrice = 100,
                IsAvailable = true,
                Fabrication = DateTime.Now,
                Expiration = DateTime.Now.AddDays(-1)
            };
        }
    }
}
