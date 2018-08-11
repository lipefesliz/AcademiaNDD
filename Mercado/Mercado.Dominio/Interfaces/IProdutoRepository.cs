using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Dominio.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IList<Produto> BuscarPorNome(string nome);
    }
}
