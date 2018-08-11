using BancoTabajara.Domain.Base;
using BancoTabajara.Domain.Features.Contas;
using System;

namespace BancoTabajara.Domain.Features.Movimentacoes
{
    public class Movimentacao : Entity
    {
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public TipoMovimentacaoEnum Tipo { get; set; }
        //public string Descricao { get; set; }
        public virtual Conta Conta { get; set; }

        public Movimentacao()
        {
        }

        public Movimentacao(Conta conta, TipoMovimentacaoEnum tipo, double valor)
        {
            Conta = conta;
            Valor = valor;
            Tipo = tipo;
            Data = DateTime.Now;
        }
    }
}
