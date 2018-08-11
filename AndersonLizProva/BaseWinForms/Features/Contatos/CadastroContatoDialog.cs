using AndersonLiz.Agenda.Doamain;
using System;
using System.Windows.Forms;

namespace AndersonLiz.Agenda.WinApp.Features.Contatos
{
    public partial class CadastroContatoDialog : Form
    {
        private Contato _contato;

        public Contato Contato
        {
            get { return _contato; }
            set
            {
                _contato = value;

                txtId.Text = _contato.Id.ToString();
                txtNome.Text = _contato.Nome;
                txtEmail.Text = _contato.Email;
                txtDep.Text = _contato.Departamento;
                txtEnd.Text = _contato.Endereco;
                txtTelefone.Text = _contato.Telefone;
            }
        }

        public CadastroContatoDialog()
        {
            InitializeComponent();
        }

        public CadastroContatoDialog(Contato contatoSelecionado)
        {
            InitializeComponent();

            Contato = contatoSelecionado;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (_contato == null)
            {
                _contato = new Contato();
            }

            _contato.Nome = txtNome.Text;
            _contato.Email = txtEmail.Text;
            _contato.Departamento = txtDep.Text;
            _contato.Endereco = txtEnd.Text;
            _contato.Telefone = txtTelefone.Text;

            try
            {
                _contato.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
