using DonaLaura.Domain.Base;
using DonaLaura.Domain.Features.Products;
using System;
using System.Collections.Generic;

namespace DonaLaura.Domain.Features.Sales
{
    public class Sale : Entity
    {
        public string Customer { get; set; }
        public IList<Product> Products { get; set; }
        public IList<int> Amount { get; set; }
        public decimal Profit { get; set; }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Customer))
                throw new NameIsNullOrEmptyException();

            if (Customer.Length < 4)
                throw new NameLenghtException();
        }
    }
}
