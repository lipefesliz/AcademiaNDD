using BancoTabajara.Domain.Base;
using System.Linq;

namespace BancoTabajara.Application.Base
{
    public interface IService<T> where T : Entity
    {
        long Add(T entity);

        bool Update(T entity);

        T GetById(long id);

        IQueryable<T> GetAll(int? quantidade = null);

        bool Remove(T entity);
    }
}
