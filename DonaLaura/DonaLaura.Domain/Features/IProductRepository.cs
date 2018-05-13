using DonaLaura.Domain.Base;
using DonaLaura.Domain.Features.Products;

namespace DonaLaura.Domain.Features
{
    public interface IProductRepository : IRepository<Product>
    {
        bool Exist(string name);

        Product GetByName(string name);

        bool IsTiedTo(int id);
    }
}
