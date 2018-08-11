using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Dominio.Interfaces
{
    public interface IService<T> where T : Entidade
    {
        void Add(T entidade);

        void Update(T entidade);

        void Delete(T entidade);

        IList<T> GetAll();
    }
}
