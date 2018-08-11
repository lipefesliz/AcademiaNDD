using EditoraAcademia.Domain.Features.Livros;
using EditoraAcademia.App;
using EditoraAcademia.Infra.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditoraAcademia.WinApp.Features.Livros
{
    public partial class LivroControl : UserControl
    {
        private ILivroRepository _livroRepository;
        private LivroService _livroService;

        public LivroControl()
        {
            InitializeComponent();

            _livroRepository = new LivroRepository();
            _livroService = new LivroService(_livroRepository);
        }

        public void PopularListagemLivros(IList<Livro> livros)
        {
            dgvLivros.DataSource = null;

            if (livros == null)
                return;

            dgvLivros.DataSource = livros;
            SetDataGrid();
        }

        public Livro ObtemLivroSelecionado()
        {
            try
            {
                return dgvLivros.CurrentRow.DataBoundItem as Livro;
            }
            catch
            {
                return null;
            }
        }

        private void SetDataGrid()
        {
            dgvLivros.Columns["ID"].Visible = false;
        }
    }
}
