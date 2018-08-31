using System.Linq;

namespace Anderson.MF7.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll(int? quantidade = null);

        T Add(T entity);

        bool Update(T entity);

        T GetbyId(long entityId);

        bool Remove(long entityId);
    }
}
