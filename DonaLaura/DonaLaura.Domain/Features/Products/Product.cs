using DonaLaura.Domain.Base;
using System;

namespace DonaLaura.Domain.Features.Products
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime Fabrication { get; set; }
        public DateTime Expiration { get; set; }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Name))
                throw new NameIsNullOrEmptyException();

            if (Name.Length < 4)
                throw new NameLenghtException();

            if (CostPrice <= 0)
                throw new CostPriceNegativeException();

            if (SalePrice <= CostPrice)
                throw new SalePriceLowerThanException();

            if (Expiration <= Fabrication)
                throw new ExpirationLowerThanException();
        }

        private decimal SetSalePrice()
        {
            return CostPrice + (CostPrice * 100/100);
        }
    }
}
