using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Movimentacoes;
using System.Collections.Generic;

namespace BancoTabajara.Application.Features.Contas.ViewModels
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public double Limite { get; set; }
        public double Saldo { get; set; }
        public double SaldoTotal { get { return Limite + Saldo; } }
        public bool Ativada { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}
