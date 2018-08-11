using AndersonLiz.Agenda.App;
using AndersonLiz.Agenda.Doamain.Features.Compromissos;
using AndersonLiz.Agenda.Infra.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AndersonLiz.Agenda.WinApp.Features.Compromissos
{
    public partial class CompromissoControl : UserControl
    {
        private ICompromissoRepository _compromissoRepository;
        private CompromissoService _compromissoService;

        public CompromissoControl()
        {
            InitializeComponent();

            _compromissoRepository = new CompromissoRepository();
            _compromissoService = new CompromissoService(_compromissoRepository);

            dgvCompromissos.AutoGenerateColumns = true;
        }

        public void PopularListagemComproissos(IList<Compromisso> compromissos)
        {
            dgvCompromissos.DataSource = null;

            if (compromissos == null)
                return;

            dgvCompromissos.DataSource = compromissos;
            SetDataGrid();
        }

        public Compromisso ObtemCompromissoSelecionado()
        {
            try
            {
                return dgvCompromissos.CurrentRow.DataBoundItem as Compromisso;

            }
            catch
            {
                return null;
            }
        }

        private void SetDataGrid()
        {
            dgvCompromissos.Columns["ID"].Visible = false;
            dgvCompromissos.Columns["CONTATOS"].Visible = false;

            dgvCompromissos.Columns["INICIO"].DisplayIndex = 0;
            dgvCompromissos.Columns["TERMINO"].DisplayIndex = 1;

            DateTime dataAtual = DateTime.Today.Date;

            foreach (DataGridViewRow row in dgvCompromissos.Rows)
            {
                if (dataAtual > (DateTime)row.Cells[3].Value)
                    row.DefaultCellStyle.BackColor = Color.Tomato;
            }
        }
    }
}
