using BancoTabajara.Application.Base;
using BancoTabajara.Domain.Features.Contas;
using System.Collections.Generic;

namespace BancoTabajara.Application.Features.Contas
{
    public interface IContaService : IService<Conta>
    {
        bool UpdateStatus(long id);

        bool Sacar(ModeloContaOperacoes conta);

        bool Depositar(ModeloContaOperacoes conta);

        bool Transferir(ModeloContaOperacoes conta);

        List<Extrato>GetExtratos(int id);
    }
}
