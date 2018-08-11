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
    public partial class frmTransfer : Form
    {
        public frmTransfer(Conta conta)
        {
            InitializeComponent();

            _conta = conta;

            ListContas();
        }

        //frmMain _frmMain = new frmMain();
        Conta _conta = new Conta();
        Conta _contaTransferencia = new Conta();
        ContaMEM _contaMemoria = new ContaMEM();

        private void cbContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contaTransferencia = cbTrasfereContas.SelectedItem as Conta;
        }

        private void ListContas()
        {
            cbTrasfereContas.Items.Clear();

            List<Conta> list = new List<Conta>();

            list = _contaMemoria.GetAll();

            foreach (var item in list)
            {
                cbTrasfereContas.Items.Add(item);
            }
        }

        public void AtualizaListaContas()
        {
            cbTrasfereContas.Items.Clear();

            List<Conta> list = new List<Conta>();

            list = _contaMemoria.GetAll();

            foreach (var item in list)
            {
                cbTrasfereContas.Items.Add(item);
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            double value = double.Parse(txtValor.Text);

            getValueFromTransfer(value, _conta.numero, _contaTransferencia);

            this.Close();
        }

        public void getValueFromTransfer(double value, int numero, Conta contaTransferencia)
        {
            bool resultadoTransferencia = _conta.Transfere(contaTransferencia, value, numero);

            if(resultadoTransferencia == true)
            {
                _contaMemoria.Update(_conta);
                _contaMemoria.Update(_contaTransferencia);

                AtualizaListaContas();

                MessageBox.Show("Transferencia realizada com sucesso");

            } else
            {
                MessageBox.Show("Erro ao realizar transferencia");

            }

        }
    }
}
