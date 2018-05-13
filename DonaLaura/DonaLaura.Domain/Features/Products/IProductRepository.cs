using DonaLaura.Domain.Base;

namespace DonaLaura.Domain.Features.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        bool Exist(string name);

        Product GetByName(string name);

        bool IsTiedTo(int id);
    }
}
