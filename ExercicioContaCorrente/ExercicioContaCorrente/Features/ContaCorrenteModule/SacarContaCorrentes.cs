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
    public partial class SacarContaCorrentes : Form
    {
        public SacarContaCorrentes()
        {
            InitializeComponent();
        }

        public Conta ContaSaque
        {
            get
            {
                double valor = double.Parse(txtWithdrawValue.Text);

                getValueFromWithdraw(valor);

                return _conta;
            }

            set
            {
                _conta = value;
            }
        }

        Conta _conta = new Conta();

        public void getValueFromWithdraw(double value)
        {
            bool retornoSaque = _conta.Saca(value, _conta.numero);

            if (retornoSaque)
            {
                MessageBox.Show("Saque realizado com sucesso");
            }
            else
            {
                MessageBox.Show("Não foi possível realizar o saque");
            }
        }
    }
}
