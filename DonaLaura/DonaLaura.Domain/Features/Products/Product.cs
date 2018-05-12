using System;

namespace DonaLaura.Domain.Features.Products
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal SalePrice { get { return SalePrice; }  private set { GetSalePrice(); } }

        public decimal CostPrice { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime Fabrication { get; set; }

        public DateTime Expiration { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(Name))
                throw new NameIsNullOrEmptyException();

            if (Name.Length < 4)
                throw new NameLenghtException();

            if (SalePrice <= 0)
                throw new SalePriceNegativeException();

            if (CostPrice <= 0)
                throw new CostPriceNegativeException();

            if (CostPrice >= SalePrice)
                throw new CostPriceHigherThanException();

            if (Expiration <= Fabrication)
                throw new ExpirationLowerThanException();
        }

        private decimal GetSalePrice()
        {
            return CostPrice + (CostPrice * 100/100);
        }
    }
}
