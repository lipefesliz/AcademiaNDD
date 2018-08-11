using Mercado.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercado.Dominio;
using System.IO;
using CsvHelper;
using System.Collections;
using System.Data;

namespace Mercado.Infra.CSV
{
    public class ProdutoCSVRepository : IProdutoRepository
    {
        public void Adicionar(Produto entidade)
        {
            IList<Produto> records = BuscarTodos();
            if(records.Count > 0)
            {
                entidade.Id = records.Last().Id + 1;
            }
            else
            {
                entidade.Id = 1;
            }
            records.Add(entidade);
            File.Delete(@"produto.csv");
            EscreverNoCsv(@"produto.csv", records);
        }
        private void EscreverNoCsv(string caminho, IList<Produto> records)
        {

            File.Create(caminho).Close();

            using (StreamWriter sr = new StreamWriter(new FileStream(@"produto.csv", FileMode.Open)))
            {
                using (CsvWriter csvWriter = new CsvWriter(sr))
                {
                    csvWriter.Configuration.Delimiter = ";";
                    csvWriter.WriteRecords(records);
                }
            }
        }
        public IList<Produto> BuscarPorNome(string nome)
        {
            IList<Produto> lista = new List<Produto>();
            IList<Produto> records = BuscarTodos();

            foreach (Produto item in records)
            {
                if (item.Nome.Contains(nome))
                {
                    lista.Add(item);
                }              
            }
            return lista;
        }

        public IList<Produto> BuscarTodos()
        {
            string caminho = @"produto.csv";
            IList<Produto> produtos = new List<Produto>();
            if (File.Exists(caminho))
            {
                using (StreamReader sr = new StreamReader(new FileStream(@"produto.csv", FileMode.Open)))
                {
                    using (CsvReader reader = new CsvReader(sr))
                    {
                        reader.Configuration.Delimiter = ";";

                        reader.Configuration.BadDataFound = null;
                        produtos = reader.GetRecords<Produto>().ToList();
                    }
                }
            }
            return produtos;
        }
        public void Editar(Produto entidade)
        {
            IList<Produto> records = BuscarTodos();
            foreach (var item in records)
            {
                if (item.Id == entidade.Id)
                {
                    int pos = records.IndexOf(item);
                    records[pos] = entidade;
                    break;
                }
            }
            File.Delete(@"produto.csv");
            EscreverNoCsv(@"produto.csv", records);
        }
        public void Excluir(Produto entidade)
        {
            IList<Produto> produtos = BuscarTodos();
            foreach (var item in produtos)
            {
                if (item.Id == entidade.Id)
                {
                    produtos.Remove(item);
                    break;
                }
            }
            File.Delete(@"produto.csv");
            EscreverNoCsv(@"produto.csv", produtos);
        }
    }
}
