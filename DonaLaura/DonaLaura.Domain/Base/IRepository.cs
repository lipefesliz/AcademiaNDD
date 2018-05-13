using System.Collections.Generic;

namespace DonaLaura.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T entity);

        T Update(T entity);

        T Get(long id);

        IList<T> GetAll();

        void Delete(long id);
    }
}
