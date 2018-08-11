using EditoraAcademia.Domain.Features.Livros;
using System;
using System.Windows.Forms;

namespace EditoraAcademia.WinApp.Features.Livros
{
    public partial class CadastroLivroDialog : Form
    {
        private Livro _livro;

        public Livro Livro
        {
            get { return _livro; }
            set
            {
                _livro = value;

                txtId.Text = _livro.Id.ToString();
                txtTitulo.Text = _livro.Titulo;
                txtAno.Text = _livro.Ano;
                txtAutor.Text = _livro.Autor;
                txtVolume.Text = _livro.Volume;
            }
        }

        public CadastroLivroDialog()
        {
            InitializeComponent();
        }

        public CadastroLivroDialog(Livro livroSelecionado)
        {
            InitializeComponent();

            Livro = livroSelecionado;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (_livro == null)
            {
                _livro = new Livro();
            }

            _livro.Titulo = txtTitulo.Text;
            _livro.Ano = txtAno.Text;
            _livro.Autor = txtAutor.Text;
            _livro.Volume = txtVolume.Text;

            try
            {
                _livro.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
