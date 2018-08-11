using EditoraAcademia.Domain.Features.Editoras;
using EditoraAcademia.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditoraAcademia.Features.Editoras
{
    public partial class CadastroEditoraDialog : Form
    {
        private Editora _editora;

        public Editora Editora
        {
            get { return _editora; }
            set
            {
                _editora = value;

                txtId.Text = _editora.Id.ToString().Trim();
                txtNome.Text = _editora.Nome.Trim();
                txtEndereco.Text = _editora.Endereco.Trim();
                txtTelefone.Text = _editora.Telefone.Trim();

                foreach (var item in _editora.Livros)
                {
                    listBoxLivros.Items.Add(item);
                }
            }
        }

        public CadastroEditoraDialog(IList<Livro> livros)
        {
            InitializeComponent();

            if (livros == null || livros.Count == 0)
                throw new ArgumentNullException("Deve ter livros cadastrados!");

            AtualizaCombobox(livros);
        }

        public CadastroEditoraDialog(Editora editraSelecionado, IList<Livro> livros)
        {
            InitializeComponent();

            AtualizaCombobox(livros);

            Editora = editraSelecionado;
        }

        private void AtualizaCombobox(IList<Livro> livros)
        {
            cmbLivros.Items.Clear();

            foreach (var item in livros)
            {
                cmbLivros.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!listBoxLivros.Items.Contains(cmbLivros.SelectedItem))
                listBoxLivros.Items.Add(cmbLivros.SelectedItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listBoxLivros.Items.Remove(listBoxLivros.SelectedItem);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_editora == null)
            {
                _editora = new Editora();
            }

            IList<Livro> list = new List<Livro>();

            _editora.Id = int.Parse(txtId.Text);
            _editora.Nome = txtNome.Text.Trim();
            _editora.Endereco = txtEndereco.Text.Trim();
            _editora.Telefone = txtTelefone.Text.Trim();

            //_editora.Livros = listBoxLivros.SelectedItems.Cast<Livro>().ToList();
            foreach (var item in listBoxLivros.Items)
            {
                list.Add(item as Livro);
            }
            _editora.Livros = list;

            try
            {
                _editora.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
