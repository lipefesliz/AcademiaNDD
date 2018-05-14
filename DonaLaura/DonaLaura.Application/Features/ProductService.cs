using System.Collections.Generic;
using System.Data;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Products.Exceptions;

namespace DonaLaura.Application.Features
{
    public class ProductService : IService<Product>
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product entity)
        {
            entity.Validate();

            bool productFounded = _productRepository.Exist(entity.Name);
            if (productFounded)
                throw new DuplicatedNameException();

            return _productRepository.Add(entity);
        }

        public void Delete(Product entity)
        {
            if (entity.Id == 0)
            {
                throw new IdentifierUndefinedException();
            }

            if (IsTiedTo(entity.Id))
                throw new TiedException();

            _productRepository.Delete(entity.Id);
        }

        public Product Get(long id)
        {
            if (id <= 0)
            {
                throw new IdentifierUndefinedException();
            }

            return _productRepository.Get(id);
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Update(Product entity)
        {
            if (entity.Id <= 0)
            {
                throw new IdentifierUndefinedException();
            }

            entity.Validate();

            Product productFounded = _productRepository.GetByName(entity.Name);
            if (productFounded != null)
            {
                if (productFounded.Id != entity.Id)
                    throw new DuplicatedNameException();
            }

            return _productRepository.Update(entity);
        }

        public bool IsTiedTo(long id)
        {
            if (id <= 0)
            {
                throw new IdentifierUndefinedException();
            }

            return _productRepository.IsTiedTo(id);
        }
    }
}
