using System;

namespace BancoTabajara.Application.Features.Contas
{
    public class Extrato
    {
        public int NumeroConta { get; set; }
        public string Titular { get; set; }
        public DateTime Data { get; set; }
        public double Credito { get; set; }
        public double Debito { get; set; }
    }
}
