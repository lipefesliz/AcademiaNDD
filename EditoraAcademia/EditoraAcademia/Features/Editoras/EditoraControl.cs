using EditoraAcademia.App;
using EditoraAcademia.Domain.Features.Editoras;
using EditoraAcademia.Infra.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditoraAcademia.WinApp.Features.Editoras
{
    public partial class EditoraControl : UserControl
    {
        private IEditoraRepository _editoraRepository;
        private EditoraService _editoraService;

        public EditoraControl()
        {
            InitializeComponent();

            _editoraRepository = new EditoraRepository();
            _editoraService = new EditoraService(_editoraRepository);
        }

        public void PopularListagemEditoras(IList<Editora> editoras)
        {
            dgvEditora.DataSource = null;

            if (editoras == null)
                return;

            dgvEditora.DataSource = editoras;
            SetDataGrid();
        }

        public Editora ObtemEditoraSelecionada()
        {
            try
            {
                return dgvEditora.CurrentRow.DataBoundItem as Editora;
            }
            catch
            {
                return null;
            }
        }

        private void SetDataGrid()
        {
            dgvEditora.Columns["ID"].Visible = false;
            dgvEditora.Columns["LIVROS"].Visible = false;
        }
    }
}
