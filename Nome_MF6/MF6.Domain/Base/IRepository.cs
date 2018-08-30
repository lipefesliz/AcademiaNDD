using System.Linq;

namespace MF6.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();

        T Add(T entity);

        bool Update(T entity);

        T GetbyId(long entityId);

        bool Remove(long entityId);
    }
}
