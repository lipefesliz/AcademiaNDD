using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using System;
using System.Collections.Generic;

namespace DonaLaura.Common.Tests.Features.Sales
{
    public static partial class ObjectMother
    {
        public static Sale CreateValidSale()
        {
            return new Sale
            {
                Id = 1,
                Customer = "Zeca",
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Sabonete",
                        CostPrice = 2,
                        SalePrice = 4,
                        IsAvailable = true,
                        Fabrication = DateTime.Now,
                        Expiration = DateTime.Now.AddTicks(DateTime.Now.Ticks)
                    }
                },
                Amount = new List<int> { 3, 6},
                Profit = 1000
            };
        }

        public static Sale CreateInvalidSaleEmptyProduct()
        {
            return new Sale
            {
                Id = 1,
                Customer = "Zeca",
                Amount = new List<int> { 3, 6 },
                Profit = 1000
            };
        }

        public static Sale CreateInvalidSaleEmptyCustomer()
        {
            return new Sale
            {
                Id = 1,
                Customer = "",
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 8,
                        Name = "Shampoo",
                        CostPrice = 25,
                        SalePrice = 50,
                        IsAvailable = true,
                        Fabrication = DateTime.Now,
                        Expiration = DateTime.Now.AddDays(30)
                    },

                    new Product
                    {
                        Id = 9,
                        Name = "Condicionador",
                        CostPrice = 40,
                        SalePrice = 80,
                        IsAvailable = true,
                        Fabrication = DateTime.Now,
                        Expiration = DateTime.Now.AddDays(30)
                    }
                },
                Amount = new List<int> { 3, 6 },
                Profit = 1000
            };
        }

        public static Sale CreateInvalidSaleLeghtCustomer()
        {
            return new Sale
            {
                Id = 1,
                Customer = "Ivo",
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = 8,
                        Name = "Shampoo",
                        CostPrice = 25,
                        SalePrice = 50,
                        IsAvailable = true,
                        Fabrication = DateTime.Now,
                        Expiration = DateTime.Now.AddDays(30)
                    },

                    new Product
                    {
                        Id = 9,
                        Name = "Condicionador",
                        CostPrice = 40,
                        SalePrice = 80,
                        IsAvailable = true,
                        Fabrication = DateTime.Now,
                        Expiration = DateTime.Now.AddDays(30)
                    }
                },
                Amount = new List<int> { 3, 6 },
                Profit = 1000
            };
        }
    }
}
