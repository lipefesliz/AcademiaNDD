using System.Collections.Generic;

namespace Anderson.ORM.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T entity);

        T Update(T entity);

        T Get(long id);

        IEnumerable<T> GetAll();

        void Delete(T entity);
    }
}
