using ExercicioContaCorrente.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    public partial class DepositarContaCorrente : Form
    {
        public DepositarContaCorrente()
        {
            InitializeComponent();
        }

        public Conta ContaDeposito
        {
            get
            {
                double valor = double.Parse(txtValorDeposito.Text);

                RealizaDeposito(valor);

                return _conta;
            }

            set
            {
                _conta = value;
            }
        }

        Conta _conta = new Conta();

        public void RealizaDeposito(double value)
        {
            bool retornoDeposito = _conta.Deposita(value, _conta.numero);

            if (retornoDeposito)
            {
                MessageBox.Show("Deposito realizado com sucesso");
            }
            else
            {
                MessageBox.Show("Não foi possível realizar o deposito");
            }
        }
    }
}
