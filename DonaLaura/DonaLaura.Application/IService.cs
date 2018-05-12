using DonaLaura.Domain.Base;
using System.Collections.Generic;

namespace DonaLaura.Application
{
    public interface IService<T> where T : Entity
    {
        T Add(T entidade);
        T Update(T entidade);
        T Get(long id);
        IList<T> GetAll();
        void Delete(T entidade);
    }
}
