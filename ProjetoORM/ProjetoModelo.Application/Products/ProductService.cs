using System.Collections.Generic;
using ProjetoORM.Applications;
using ProjetoORM.Domain.Exceptions;
using ProjetoORM.Domain.Features.Products;

namespace ProjetoORM.Application.Products
{
    public class ProductService : IService<Product>
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product product)
        {
            product.Validate();

            bool productFounded = _productRepository.Exist(product.Name);
            if (productFounded)
                throw new DuplicatedNameException();

            return _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            if (product.Id == 0)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(product))
                throw new IsTiedException();

            _productRepository.Delete(product);
        }

        public Product Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            return _productRepository.Get(id);
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Update(Product product)
        {
            if (product.Id <= 0)
                throw new IdentifierUndefinedException();

            product.Validate();

            Product productFounded = _productRepository.GetByName(product.Name);
            if (productFounded != null)
                if (productFounded.Id != product.Id)
                    throw new DuplicatedNameException();

            return _productRepository.Update(product);
        }

        public bool IsTiedTo(Product product)
        {
            return _productRepository.IsTiedTo(product);
        }
    }
}
