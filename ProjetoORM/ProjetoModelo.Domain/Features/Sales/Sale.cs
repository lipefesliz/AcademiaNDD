using ProjetoORM.Domain.Base;
using ProjetoORM.Domain.Features.Products;
using System;
using System.Collections.Generic;

namespace ProjetoORM.Domain.Features.Sales
{
    public class Sale : Entity
    {
        public string Customer { get; set; }
        public virtual ICollection<Product> Products { get; set; }
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

            if (Customer.Length < 4)
                throw new NameLenghtException();

            if (Products.Count == 0)
                throw new EmptyProductsException();
        }
    }
}
