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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            Conta conta1 = new Conta();
            conta1.saldo = 100;
            conta1.especial = true;
            conta1.numero = 123;
            //registra na memoria
            _contaMemoria.Insert(conta1);

            Console.WriteLine("Saldo de {0}R$ \n", conta1.Saldo());

            Conta conta2 = new Conta();
            conta2.saldo = 100;
            conta2.especial = false;
            conta2.numero = 1298;
            _contaMemoria.Insert(conta2);

            ListContas();
        }

        private Conta _conta = new Conta();
        ContaMEM _contaMemoria = new ContaMEM();

        List<Conta> list = new List<Conta>();

        private void cbContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _conta = cbContas.SelectedItem as Conta;

            tabBanco.SelectedIndex = 0;
            txtNumero.Text = _conta.numero.ToString();
            txtSaldo.Text = _conta.saldo.ToString();
            cbxEspecial.Checked = _conta.especial ? true : false;
        }

        private void ListContas()
        {
            cbContas.Items.Clear();

            //List<Conta> list = new List<Conta>();

            list = _contaMemoria.GetAll();

            foreach (var item in list)
            {
                cbContas.Items.Add(item);
            }
        }

        public void AtualizaListaContas()
        {
            cbContas.Items.Clear();

            //List<Conta> list = new List<Conta>();

            list = _contaMemoria.GetAll();

            foreach (var item in list)
            {
                cbContas.Items.Add(item);
            }
        }

        private void btnSaque_Click(object sender, EventArgs e)
        {
            if(_conta.numero == 0)
            {
                MessageBox.Show("Nenhuma conta selecionada");
            }
            else
            {
                new frmWithdraw(_conta).Show();
            }
        }

        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            new frmCheckingAccount().Show();
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (_conta.numero == 0)
            {
                MessageBox.Show("Nenhuma conta selecionada");
            }
            else
            {
                new frmTransfer(_conta).Show();
            }
        }

        private void contaCorrenteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
