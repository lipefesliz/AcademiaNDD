using DonaLaura.Domain.Base;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Products.Exceptions;
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

        public override string ToString()
        {
            return string.Format("{0} - {1}", Customer, Profit);
        }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Customer))
                throw new NameIsNullOrEmptyException();

            if (Products == null)
                throw new EmptyProductsException();

            if (Customer.Length < 4)
                throw new NameLenghtException();
        }
    }
}
