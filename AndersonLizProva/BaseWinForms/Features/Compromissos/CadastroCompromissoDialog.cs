using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Doamain.Features.Compromissos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AndersonLiz.Agenda.WinApp.Features.Compromissos
{
    public partial class CadastroCompromissoDialog : Form
    {
        private Compromisso _compromisso;

        public Compromisso Compromisso
        {
            get { return _compromisso; }
            set
            {
                _compromisso = value;

                txtId.Text = _compromisso.Id.ToString();
                txtAssunto.Text = _compromisso.Assunto;
                txtLocal.Text = _compromisso.Local;
                dtInicio.Value = _compromisso.Inicio;
                dtTermino.Value = _compromisso.Termino;

                foreach (var item in _compromisso.Contatos)
                {
                    listBoxContatos.Items.Add(item);
                }
            }
        }

        public CadastroCompromissoDialog(IList<Contato> contatos)
        {
            InitializeComponent();

            if (contatos == null || contatos.Count == 0)
                throw new ArgumentNullException("Deve ter contatos cadastrados!");

            AtualizaCombobox(contatos);
        }

        public CadastroCompromissoDialog(Compromisso compromissoSelecionado, IList<Contato> contatos)
        {
            InitializeComponent();

            AtualizaCombobox(contatos);

            Compromisso = compromissoSelecionado;
        }

        private void AtualizaCombobox(IList<Contato> contatos)
        {
            cmbContatos.Items.Clear();

            foreach (var item in contatos)
            {
                cmbContatos.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!listBoxContatos.Items.Contains(cmbContatos.SelectedItem))
                listBoxContatos.Items.Add(cmbContatos.SelectedItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listBoxContatos.Items.Remove(listBoxContatos.SelectedItem);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(_compromisso == null)
            {
                _compromisso = new Compromisso();
            }
            IList<Contato> list = new List<Contato>();

            _compromisso.Id = int.Parse(txtId.Text);
            _compromisso.Assunto = txtAssunto.Text;
            _compromisso.Local = txtLocal.Text;
            _compromisso.Inicio = dtInicio.Value;
            _compromisso.Termino = dtTermino.Value;

            foreach (var item in listBoxContatos.Items)
            {
                list.Add(item as Contato);
            }
            _compromisso.Contatos = list;

            //_compromisso.Contatos = listBoxContatos.SelectedItems.Cast<Contato>().ToList();

            try
            {
                _compromisso.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
