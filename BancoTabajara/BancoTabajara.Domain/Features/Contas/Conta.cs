using BancoTabajara.Domain.Base;
using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas.Exceptions;
using BancoTabajara.Domain.Features.Movimentacoes;
using System.Collections.Generic;

namespace BancoTabajara.Domain.Features.Contas
{
    public class Conta : Entity
    {
        public int Numero { get; set; }
        public double Limite { get; set; }
        public double Saldo { get; set; }
        public double SaldoTotal { get { return Limite + Saldo; } }
        public bool Ativada { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

        public Conta()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public override bool Validate()
        {
            if (!this.Ativada)
                throw new ContaDesativadaException();

            return true;
        }

        public void Sacar(double valor)
        {
            this.Validate();

            if (valor > this.SaldoTotal)
                throw new SaldoInsuficienteException();

            this.Saldo -= valor;
            this.SalvarMovimentacao(TipoMovimentacaoEnum.DEBITO, valor);
        }

        public void Depositar(double valor)
        {
            this.Validate();

            this.Saldo += valor;
            this.SalvarMovimentacao(TipoMovimentacaoEnum.CREDITO, valor);
        }

        public void Transferir(double valor, Conta contaDestino)
        {
            this.Validate();
            contaDestino.Validate();

            if (valor > this.SaldoTotal)
                throw new SaldoInsuficienteException();

            this.Sacar(valor);
            contaDestino.Depositar(valor);
        }

        private void SalvarMovimentacao(TipoMovimentacaoEnum tipo, double valor)
        {
            var Movimentacao = new Movimentacao(this, tipo, valor);

            this.Movimentacoes.Add(Movimentacao);
        }
    }
}
