using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Domain.Features.Movimentacoes;
using System;

namespace BancoTabajara.Common.Tests.Features.Contas
{
    public static partial class ObjectMother
    {
        public static Conta ObterContaValida()
        {
            return new Conta
            {
                Id = 2,
                Ativada = true,
                Cliente = new Cliente()
                {
                    Id = 2,
                    Cpf = "123456789",
                    Nascimento = DateTime.Now,
                    Nome = "cliente",
                    Rg = "123456789"
                },
                Limite = 100,
                Numero = 321,
                Saldo = 1000,
            };
        }

        public static Conta ObterContaComMovimentacao()
        {
            var conta = new Conta();
            conta.Id = 2;
            conta.Ativada = true;
            conta.Cliente = new Cliente()
            {
                Id = 2,
                Cpf = "123456789",
                Nascimento = DateTime.Now,
                Nome = "cliente",
                Rg = "123456789"
            };
            conta.Limite = 100;
            conta.Numero = 321;
            conta.Saldo = 1000;
            conta.Movimentacoes.Add(new Movimentacao() { Id = 0, Tipo = TipoMovimentacaoEnum.CREDITO, Valor = 100 });

            return conta;
        }

        public static Conta ObterConta(Cliente cliente)
        {
            return new Conta
            {
                Id = 2,
                Ativada = true,
                Cliente = cliente,
                Limite = 100,
                Numero = 321,
                Saldo = 1000,
            };
        }

        public static Conta ObterContaInativa()
        {
            return new Conta
            {
                Id = 2,
                Ativada = false
            };
        }
    }
}
