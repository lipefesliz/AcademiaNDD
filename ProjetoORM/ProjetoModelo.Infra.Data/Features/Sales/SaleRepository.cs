using System.Collections.Generic;
using ProjetoORM.Domain.Features.Products;
using ProjetoORM.Domain.Features.Sales;

namespace ProjetoModelo.Infra.Data.Features.Sales
{
    public class SaleRepository : ISaleRepository
    {
        public Sale Add(Sale sale)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Sale sale)
        {
            throw new System.NotImplementedException();
        }

        public Sale Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Sale> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Sale GetByCustomer(string name)
        {
            throw new System.NotImplementedException();
        }

        public IList<Product> GetProductsFromSale(long id)
        {
            throw new System.NotImplementedException();
        }

        public Sale Update(Sale sale)
        {
            throw new System.NotImplementedException();
        }
    }
}
