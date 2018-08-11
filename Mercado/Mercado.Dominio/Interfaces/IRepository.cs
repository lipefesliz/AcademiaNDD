using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Dominio.Interfaces
{
    public interface IRepository<T> where T : Entidade
    {
        void Adicionar(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);

        IList<T> BuscarTodos();
    }
}
