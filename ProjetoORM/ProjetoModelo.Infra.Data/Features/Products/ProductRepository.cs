using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjetoORM.Domain.Features.Products;
using ProjetoORM.Infra.Data.Base;

namespace ProjetoORM.Infra.Data.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        private ProjetoOrmContext _context;

        public ProductRepository(ProjetoOrmContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            product = _context.Products.Add(product);

            _context.SaveChanges();

            return product;
        }

        public void Delete(Product product)
        {
            _context.Products.Attach(product);
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        public bool Exist(string name)
        {
            var product = _context.Products.Find(name);

            if (product != null)
                return true;

            return false;
        }

        public Product Get(long id)
        {
            var product = _context.Products.Find(id);

            return product;
        }

        public IList<Product> GetAll()
        {
            var products = _context.Products.ToList();

            return products;
        }

        public Product GetByName(string name)
        {
            var product = _context.Products.Find(name);

            return product;
        }

        public bool IsTiedTo(Product product)
        {
            var sale = _context.Sales.Where(c => c.Products.Contains(product));

            if (sale != null)
                return true;

            return false;
        }

        public Product Update(Product product)
        {
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();

            return product;
        }
    }
}
