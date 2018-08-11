using BancoTabajara.Domain.Base;
using System;

namespace BancoTabajara.Domain.Features.Clientes
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
