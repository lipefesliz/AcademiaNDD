using AndersonLiz.Agenda.App;
using AndersonLiz.Agenda.Doamain.Features.Compromissos;
using AndersonLiz.Agenda.Doamain.Features.Contatos;
using AndersonLiz.Agenda.Infra.Data;
using AndersonLiz.Agenda.WinApp.Features;
using AndersonLiz.Agenda.WinApp.Features.Compromissos;
using AndersonLiz.Agenda.WinApp.Features.Contatos;
using System;
using System.Windows.Forms;

namespace AndersonLiz.Agenda.WinApp
{
    public partial class Principal : Form
    {
        private static IContatoRepository _contatoRepository = new ContatoRepository();
        private static ICompromissoRepository _compromissoRepository = new CompromissoRepository();

        private ContatoService _contatoService = new ContatoService(_contatoRepository);
        private CompromissoService _compromissoService = new CompromissoService(_compromissoRepository);

        private GerenciadorFormulario _gerenciador;
        private ContatoGerenciadorFormulario _contatoGerenciador;
        private CompromissoGerenciadorFormulario _compromissoGerenciador;

        public Principal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            _compromissoGerenciador = new CompromissoGerenciadorFormulario(_compromissoService, _contatoService);

            CarregarCadastro(_compromissoGerenciador);
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

        private void contatosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_contatoGerenciador == null)
                _contatoGerenciador = new ContatoGerenciadorFormulario(_contatoService);

            CarregarCadastro(_contatoGerenciador);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                _gerenciador.Add();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

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
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Update();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void compromissosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_compromissoGerenciador == null)
                _compromissoGerenciador = new CompromissoGerenciadorFormulario(_compromissoService, _contatoService);

            CarregarCadastro(_compromissoGerenciador);
        }
    }
}
