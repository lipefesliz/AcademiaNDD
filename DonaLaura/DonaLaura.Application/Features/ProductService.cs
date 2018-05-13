using System;
using System.Collections.Generic;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features;
using DonaLaura.Domain.Features.Products;

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

            return _productRepository.Add(entity);
        }

        public void Delete(Product entity)
        {
            if (entity.Id == 0)
            {
                throw new IdentifierUndefinedException();
            }

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
            return _productRepository.Update(entity);
        }
    }
}
