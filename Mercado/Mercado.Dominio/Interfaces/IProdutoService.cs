using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Dominio.Interfaces
{
    public interface IProdutoService : IService<Produto>
    {
        IList<Produto> GetByName(string nome);
    }
}
