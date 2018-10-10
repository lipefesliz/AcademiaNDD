using Projeto_Prova_Tdd.Domain.Base;
using System.Collections.Generic;

namespace Projeto_Prova_Tdd.Applications
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
