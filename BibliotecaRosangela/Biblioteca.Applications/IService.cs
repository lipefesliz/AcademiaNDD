using Biblioteca.Domain.Base;
using System.Collections.Generic;

namespace Biblioteca.Applications
{
    public interface IService<T> where T : Entity
    {
        T Add(T entity);

        T Update(T entity);

        T Get(long id);

        IList<T> GetAll();

        void Delete(T entity);
    }
}
