using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using System.Collections.Generic;

namespace DonaLaura.Applications.Features
{
    public class SaleService : IService<Sale>
    {
        private ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Sale Add(Sale entity)
        {
            entity.Validate();

            return _saleRepository.Add(entity);
        }

        public void Delete(Sale entity)
        {
            if (entity.Id == 0)
            {
                throw new IdentifierUndefinedException();
            }

            _saleRepository.Delete(entity.Id);
        }

        public Sale Get(long id)
        {
            if (id == 0)
            {
                throw new IdentifierUndefinedException();
            }

            return _saleRepository.Get(id);
        }

        public IList<Sale> GetAll()
        {
            return _saleRepository.GetAll();
        }

        public IList<Product> GetProductsFromSales(long id)
        {
            if (id == 0)
            {
                throw new IdentifierUndefinedException();
            }

            return _saleRepository.GetProductsFromSale(id);
        }

        public Sale Update(Sale entity)
        {
            if (entity.Id <= 0)
            {
                throw new IdentifierUndefinedException();
            }

            entity.Validate();

            return _saleRepository.Update(entity);
        }
    }
}
