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
    public partial class frmDeposito : Form
    {
        public frmDeposito(Conta conta)
        {
            InitializeComponent();

            _conta = conta;
        }

        frmMain _frmMain = new frmMain();
        Conta _conta = new Conta();
        ContaMEM _contaMemoria = new ContaMEM();

        private void btnWithdrawConfirm_Click(object sender, EventArgs e)
        {
            double value = double.Parse(txtWithdrawValue.Text);

            getValueFromWithdraw(value);

            this.Close();
        }

        public void getValueFromWithdraw(double value)
        {
            _conta.Deposita(value, _conta.numero);

            _contaMemoria.Update(_conta);

            MessageBox.Show("Deposito realizado com sucesso");
        }
    }
}
