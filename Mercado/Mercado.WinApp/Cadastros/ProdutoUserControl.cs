using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.Serviço;
using Mercado.Dominio;
using Mercado.Infra.SQL;
using Mercado.Dominio.Interfaces;

namespace Mercado.WinApp.Cadastros
{
    public partial class ProdutoUserControl : UserControl
    {
        IProdutoRepository _repositorio;
        private ProdutoService _produtoServico;
        public ProdutoUserControl(IProdutoRepository repository)
        {
            InitializeComponent();            
            _repositorio = repository;
            _produtoServico = new ProdutoService(_repositorio);
            CarregarLista();
        }

        public void CarregarLista()
        {
            listBox1.Items.Clear();
            var list = _produtoServico.GetAll();
            if(list == null)
            {
                return;
            }
            else
            {
                foreach (var item in list)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        public void BuscarPorNome(string nome)
        {
            IList<Produto> lista = _produtoServico.GetByName(nome);

            if (lista.Count > 0)
            {
                listBox1.Items.Clear();
                foreach (Produto p in lista)
                {
                    listBox1.Items.Add(p);
                }
            }
            else
            {
                CarregarLista();
                MessageBox.Show("Não existe produto com este nome!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public Produto GetSelect() {
            Produto produto = listBox1.SelectedItem as Produto;
            return produto;
        }
    }
}
