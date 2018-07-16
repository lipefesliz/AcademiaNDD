using MediaProva.Domain.Base;
using System.Collections.Generic;

namespace MediaProva.Applications
{
    public interface IService<T> where T : Entity
    {
        T Add(T entity);

        T Update(T entity);

        T Get(long id);

        IEnumerable<T> GetAll();

        void Delete(T entity);
    }
}
