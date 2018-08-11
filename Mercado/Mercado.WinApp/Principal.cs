using Mercado.Dominio.Interfaces;
using Mercado.Infra.CSV;
using Mercado.Infra.SQL;
using Mercado.Infra.XML;
using Mercado.Serviço;
using Mercado.WinApp.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado.WinApp
{
    public partial class Principal : Form
    {
        private ProdutoService _produtoServico;
        private GerenciadorFormulario _gerente;
        private IProdutoRepository _repository;

        public Principal()
        {
            InitializeComponent();
            rdBtnSQL.Checked = true;
            _repository = new ProdutoSQLRepository();
            _produtoServico = new ProdutoService(_repository);
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CarregarCadastro(new ProdutoGerenciadorFormulario(_repository));
        }

        private void CarregarCadastro(GerenciadorFormulario gerente)
        {
            _gerente = gerente;
            AtivarBotoes();
            lbllControle.Text = _gerente.ObtemTipoCadastro();

            UserControl _userControl = _gerente.ObterTipoUserControl();

            btnCadastrar.Text = _gerente.btnCad;
            _userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_userControl);
        }

        private void AtivarBotoes()
        {
            btnCadastrar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            rdBtnSQL.Enabled = true;
            rdbtnXML.Enabled = true;
            tdBtnCSV.Enabled = true;
            btnFiltro.Enabled = true;
            btnLimpar.Enabled = true;
            txtNome.Enabled = true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _gerente.Adicionar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _gerente.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _gerente.Excluir();
        }

        private void rdBtnSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (_repository != null)
            {
                _repository = null;
                _repository = new ProdutoSQLRepository();
                CarregarCadastro(new ProdutoGerenciadorFormulario(_repository));
            }
        }

        private void rdbtnXML_CheckedChanged(object sender, EventArgs e)
        {
            if (_repository != null)
            {
                _repository = null;
                _repository = new ProdutoXMLRepository();
                CarregarCadastro(new ProdutoGerenciadorFormulario(_repository));
            }
            else
            {
                _repository = new ProdutoXMLRepository();
            }

        }

        private void tdBtnCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (_repository != null)
            {
                _repository = null;
                _repository = new ProdutoCSVRepository();
                CarregarCadastro(new ProdutoGerenciadorFormulario(_repository));
            }
            else
            {
                _repository = new ProdutoCSVRepository();
            }

        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {

            if (txtNome.Text.Length <= 0)
            {
                MessageBox.Show("Digite um nome para a busca!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _gerente.BuscarPorNome(txtNome.Text);
                txtNome.Clear();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            _gerente.AtualizarLista();
            txtNome.Clear();
        }
    }
}
