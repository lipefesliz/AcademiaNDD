using System.Collections.Generic;

namespace DonaLaura.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T entidade);

        T Update(T entidade);

        T Get(long id);

        IList<T> GetAll();

        void Delete(long id);
    }
}
