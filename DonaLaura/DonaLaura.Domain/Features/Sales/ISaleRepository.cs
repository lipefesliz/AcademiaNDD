using DonaLaura.Domain.Base;
using DonaLaura.Domain.Features.Products;
using System.Collections.Generic;

namespace DonaLaura.Domain.Features.Sales
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Sale GetByCustomer(string name);

        IList<Product> GetProductsFromSale(long id);
    }
}
