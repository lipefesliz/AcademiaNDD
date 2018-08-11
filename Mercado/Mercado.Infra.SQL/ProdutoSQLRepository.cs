using Mercado.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercado.Dominio;
using Mercado.Infra.Database;
using System.Data;

namespace Mercado.Infra.SQL
{
    public class ProdutoSQLRepository : IProdutoRepository
    {
        #region SCRIPTS SQL
        private const string _sqlInsert = "INSERT INTO TBProdutos (nome, preco, tipo, quantidade) VALUES({0}Nome, {0}Preco, {0}Tipo, {0}Quantidade)";

        private const string _sqlSelectGetByName = @"SELECT * FROM TBProdutos WHERE nome like {0}Nome";

        private const string _sqlSelectAll = "SELECT * FROM TBProdutos order by Nome";

        private const string _sqlDelete = "DELETE FROM TBProdutos WHERE ID={0}ID";

        private const string _sqlUpdate = "UPDATE TBProdutos set nome = {0}Nome, preco = {0}Preco, tipo = {0}Tipo, quantidade = {0}Quantidade WHERE ID={0}ID";

        #endregion
        public void Adicionar(Produto entidade)
        {
            Db.Insert(_sqlInsert, Take(entidade));
        }

        public IList<Produto> BuscarPorNome(string nome)
        {
            IList<Produto> lista = new List<Produto>();
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Nome", "%" + nome + "%" } };
            lista = Db.GetAll(_sqlSelectGetByName, Make, parms);
            return lista;
        }

        public IList<Produto> BuscarTodos()
        {
            return Db.GetAll(_sqlSelectAll, Make, null);
        }

        public void Editar(Produto entidade)
        {
            Db.Update(_sqlUpdate, Take(entidade));
        }

        public void Excluir(Produto entidade)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", entidade.Id } };
            Db.Delete(_sqlDelete, parms);
        }

        private Produto Make(IDataReader reader)
        {
            Produto produto = new Produto();

            produto.Id = Convert.ToInt32(reader["ID"]);
            produto.Nome = Convert.ToString(reader["Nome"]);
            produto.Preco = Convert.ToDouble(reader["Preco"]);
            produto.Categoria = Convert.ToString(reader["Tipo"]);
            produto.Quantidade = Convert.ToInt32(reader["Quantidade"]);
            return produto;
        }
        private Dictionary<string, object> Take(Produto produto)
        {
            return new Dictionary<string, object>
            {
                { "ID", produto.Id },
                { "Nome", produto.Nome },
                { "Preco", produto.Preco },
                { "Tipo", produto.Categoria },
                { "Quantidade", produto.Quantidade }
            };
        }
    }
}
