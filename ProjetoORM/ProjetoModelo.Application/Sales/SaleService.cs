using System.Collections.Generic;
using ProjetoORM.Applications;
using ProjetoORM.Domain.Exceptions;
using ProjetoORM.Domain.Features.Products;
using ProjetoORM.Domain.Features.Sales;

namespace ProjetoModelo.Application.Sales
{
    public class SaleService : IService<Sale>
    {
        private ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Sale Add(Sale sale)
        {
            sale.Validate();

            return _saleRepository.Add(sale);
        }

        public void Delete(Sale sale)
        {
            if (sale.Id == 0)
                throw new IdentifierUndefinedException();

            _saleRepository.Delete(sale);
        }

        public Sale Get(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return _saleRepository.Get(id);
        }

        public IList<Sale> GetAll()
        {
            return _saleRepository.GetAll();
        }

        public IList<Product> GetProductsFromSales(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return _saleRepository.GetProductsFromSale(id);
        }

        public Sale Update(Sale sale)
        {
            if (sale.Id <= 0)
                throw new IdentifierUndefinedException();

            sale.Validate();

            return _saleRepository.Update(sale);
        }
    }
}
