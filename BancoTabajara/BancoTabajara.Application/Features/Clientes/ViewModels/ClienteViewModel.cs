using System;

namespace BancoTabajara.Application.Features.Clientes.ViewModels
{
    public class ClienteViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
