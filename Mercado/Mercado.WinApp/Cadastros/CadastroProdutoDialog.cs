using Mercado.Dominio;
using Mercado.Serviço;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado.WinApp.Cadastros
{
    public partial class CadastroProdutoDialog : Form
    {
        ProdutoService _produtoServico;
        Produto _produto;

        public CadastroProdutoDialog(ProdutoService produtoServico, string titulo, Produto produto = null)
        {
            InitializeComponent();
            PopularCategoria();
            this.Text = titulo;
            _produtoServico = produtoServico;
            NovoProduto = produto;
            if (NovoProduto != null)
            {
                txtProduto.Text = NovoProduto.Nome;
                numericPreco.Value = (decimal)NovoProduto.Preco;
                numericQuantidade.Value = NovoProduto.Quantidade;
                cmbTipo.SelectedIndex = cmbTipo.FindString(NovoProduto.Categoria);
            }
        }

        public Produto NovoProduto
        {
            get
            {
                return _produto;
            }
            set
            {
                _produto = value;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            try
            {
                if (NovoProduto != null)
                {


                    NovoProduto.Nome = txtProduto.Text.Trim();
                    NovoProduto.Preco = (double)numericPreco.Value;
                    NovoProduto.Quantidade = (int)numericQuantidade.Value;
                    NovoProduto.Categoria = cmbTipo.SelectedItem.ToString();
                    try
                    {
                        _produtoServico.Update(NovoProduto);
                        MessageBox.Show("Produto Atualizado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DialogResult = DialogResult.None;
                        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    if (cmbTipo.SelectedItem == null)
                    {     
                        MessageBox.Show("Selecione uma categoria para o pruduto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.None;
                    }   
                    else
                    {
                        NovoProduto = new Produto();
                        NovoProduto.Nome = txtProduto.Text.Trim();
                        NovoProduto.Preco = (double)numericPreco.Value;
                        NovoProduto.Quantidade = (int)numericQuantidade.Value;
                        NovoProduto.Categoria = cmbTipo.SelectedItem.ToString();
                        _produtoServico.Add(NovoProduto);
                        MessageBox.Show("Produto Cadastrado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                DialogResult = DialogResult.None;
                NovoProduto = null;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopularCategoria()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Alimentos");
            cmbTipo.Items.Add("Bebidas");
            cmbTipo.Items.Add("Limpeza");
        }
    }
}
