using ProjetoORM.Domain.Base;
using ProjetoORM.Domain.Features.Products;
using System.Collections.Generic;

namespace ProjetoORM.Domain.Features.Sales
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Sale GetByCustomer(string name);

        IList<Product> GetProductsFromSale(long id);
    }
}
