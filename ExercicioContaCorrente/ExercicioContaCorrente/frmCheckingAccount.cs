using ExercicioContaCorrente.Applications;
using ExercicioContaCorrente.Domain;
using ExercicioContaCorrente.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente
{
    public partial class frmCheckingAccount : Form
    {
        public frmCheckingAccount()
        {
            InitializeComponent();
        }

        Conta _conta = new Conta();
        ContaService _contaService = new ContaService();
        ContaMEM _contaMemoria = new ContaMEM();
        //frmMain _frmMain = new frmMain();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FormContaToObject();

                _contaMemoria.Insert(_conta);

                //AtualizaListaContas();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void FormContaToObject()
        {
            _conta.numero = int.Parse(txtNumber.Text);
            _conta.saldo = double.Parse(txtBalance.Text);
            _conta.especial = cbIsSpecial.Checked ? true : false;
        }
    }
}
