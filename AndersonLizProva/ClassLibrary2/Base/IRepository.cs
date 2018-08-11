using System.Collections.Generic;

namespace AndersonLiz.Agenda.Doamain.Base
{
    public interface IRepository<T> where T : Entidade
    {
        T Add(T entidade);

        T Update(T entidade);

        T GetById(int id);

        List<T> GetAll();

        void Delete(int id);
    }
}
