using EditoraAcademia.App;
using EditoraAcademia.Domain.Features.Editoras;
using EditoraAcademia.Domain.Features.Livros;
using EditoraAcademia.Features.Editoras;
using EditoraAcademia.Infra.Data;
using EditoraAcademia.WinApp.Features;
using EditoraAcademia.WinApp.Features.Livros;
using System;
using System.Windows.Forms;

namespace EditoraAcademia.WinApp
{
    public partial class Principal : Form
    {
        private static ILivroRepository _livroRepository = new LivroRepository();
        private static IEditoraRepository _editoraRepository = new EditoraRepository();

        private LivroService _livroService = new LivroService(_livroRepository);
        private EditoraService _editoraService = new EditoraService(_editoraRepository);

        private GerenciadorFormulario _gerenciador;
        private LilvroGerenciadorFormulario _livroGerenciador;
        private EditoraGerenciadorFormulario _editoraGerenciador;

        public Principal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            _editoraGerenciador = new EditoraGerenciadorFormulario(_editoraService, _livroService);

            CarregarCadastro(_editoraGerenciador);
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            lblStatus.Text = _gerenciador.ObtemTipoCadastro();

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panControl.Controls.Clear();

            panControl.Controls.Add(listagem);

            _gerenciador.AtualizarLista();

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            lblAdd.Enabled = true;
            lblDelete.Enabled = true;
            lblUpdate.Enabled = true;
        }

        private void livrosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_livroGerenciador == null)
                _livroGerenciador = new LilvroGerenciadorFormulario(_livroService);

            CarregarCadastro(_livroGerenciador);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                _gerenciador.Add();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _gerenciador.Add();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _gerenciador.Delete();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _gerenciador.Update();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_editoraGerenciador == null)
                _editoraGerenciador = new EditoraGerenciadorFormulario(_editoraService, _livroService);

            CarregarCadastro(_editoraGerenciador);
        }
    }
}
