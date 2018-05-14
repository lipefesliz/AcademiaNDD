using DonaLaura.Domain.Features.Sales;

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
                Profit = 1000
            };
        }

        public static Sale CreateInvalidSaleEmptyCustomer()
        {
            return new Sale
            {
                Id = 1,
                Customer = "",
                Profit = 1000
            };
        }

        public static Sale CreateInvalidSaleLeghtCustomer()
        {
            return new Sale
            {
                Id = 1,
                Customer = "Ivo",
                Profit = 1000
            };
        }
    }
}
