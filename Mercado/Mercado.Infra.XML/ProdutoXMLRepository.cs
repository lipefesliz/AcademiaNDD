using Mercado.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Mercado.Dominio;

namespace Mercado.Infra.XML
{
    public class ProdutoXMLRepository : IProdutoRepository
    {
        private readonly string _path = @"produto.xml";
        private XmlTextWriter _writer;
        XmlTextReader _reader;
        public ProdutoXMLRepository()
        {
            _reader = new XmlTextReader(_path);
        }

        public void Adicionar(Produto entidade)
        {
            try
            {
                var lista = BuscarTodos();

                if (lista != null)
                    entidade.Id = lista[lista.Count - 1].Id + 1;
                else
                    entidade.Id = 1;

                WriteInXML(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void WriteInXML(Produto prod)
        {
            if (!File.Exists(_path))
                using (_writer = new XmlTextWriter(_path, null))
                {
                    _writer.WriteStartDocument();
                    _writer.WriteStartElement("Mercado");
                    _writer.WriteEndElement();
                }

            XmlDocument xml = new XmlDocument();
            xml.Load(_path);
            XmlElement produto = xml.CreateElement("Product");

            XmlElement id = xml.CreateElement("Id");
            id.InnerText = prod.Id.ToString();

            XmlElement Nome = xml.CreateElement("Nome");
            Nome.InnerText = prod.Nome.ToString();

            XmlElement Categoria = xml.CreateElement("Categoria");
            Categoria.InnerText = prod.Categoria.ToString();

            XmlElement Quantidade = xml.CreateElement("Quantidade");
            Quantidade.InnerText = prod.Quantidade.ToString();

            XmlElement Preco = xml.CreateElement("Preco");
            Preco.InnerText = prod.Preco.ToString("#.##");


            produto.AppendChild(id);
            produto.AppendChild(Nome);
            produto.AppendChild(Categoria);
            produto.AppendChild(Quantidade);
            produto.AppendChild(Preco);

            xml.DocumentElement.AppendChild(produto);
            xml.Save(_path);
        }

        public IList<Produto> BuscarPorNome(string nome)
        {
            if (!File.Exists(_path)) { return null; }

            XElement xml = XElement.Load(_path);

            IEnumerable<XElement> books = xml.Elements();

            IEnumerable<XElement> titles = from book in books
                where book.Element("Nome").Value.Contains(nome)
                    select book;

            IList<Produto> lista = new List<Produto>();
            Produto prod = null;
            if (titles.Any())
            {
                foreach (XElement item in titles)
                {
                    prod = new Produto();

                    prod.Id = Convert.ToInt32(item.Element("Id").Value);
                    prod.Nome = Convert.ToString(item.Element("Nome").Value);
                    prod.Categoria = Convert.ToString(item.Element("Categoria").Value);
                    prod.Quantidade = Convert.ToInt32(item.Element("Quantidade").Value);
                    prod.Preco = Convert.ToDouble(item.Element("Preco").Value);

                    lista.Add(prod);
                }
            }

            return lista;
        }

        public IList<Produto> BuscarTodos()
        {
            Produto prod = new Produto();
            IList<Produto> listProduct = new List<Produto>();

            if (!File.Exists(_path)) { return null; }

            XElement xml = XElement.Load(_path);

            foreach (XElement item in xml.Elements())
            {
                prod = new Produto()
                {
                    Id = Convert.ToInt32(item.Element("Id").Value),
                    Nome = Convert.ToString(item.Element("Nome").Value),
                    Categoria = Convert.ToString(item.Element("Categoria").Value),
                    Quantidade = Convert.ToInt32(item.Element("Quantidade").Value),
                    Preco = Convert.ToDouble(item.Element("Preco").Value)

                };

                listProduct.Add(prod);
            }
            if (listProduct.Count() <= 0)
                return null;
            return listProduct;
        }

        public void Editar(Produto entidade)
        {
            XElement xml = XElement.Load(_path);

            IEnumerable<XElement> books = xml.Elements();

            var titles = from book in books
                where book.Element("Id").Value == entidade.Id.ToString()
                select book;

            foreach (var item in titles)
            {
                item.SetElementValue("Nome", entidade.Nome);
                item.SetElementValue("Categoria", entidade.Categoria);
                item.SetElementValue("Quantidade", entidade.Quantidade);
                item.SetElementValue("Preco", entidade.Preco);
            }
            xml.Save(_path);
        }

        public void Excluir(Produto entidade)
        {
            XElement xml = XElement.Load(_path);

            IEnumerable<XElement> books = xml.Elements();

            var titles = from book in books
                where book.Element("Id").Value == entidade.Id.ToString()
                select book;

            if (titles != null)
                titles.Remove();

            xml.Save(_path);
        }
    }
}
