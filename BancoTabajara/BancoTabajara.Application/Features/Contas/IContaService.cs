using BancoTabajara.Application.Features.Contas.Commands;
using BancoTabajara.Application.Features.Contas.Queries;
using BancoTabajara.Domain.Features.Contas;
using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Application.Features.Contas
{
    public interface IContaService
    {
        long Add(ContaRegisterCommand cmd);

        bool Update(ContaUpdateCommand cmd);

        Conta GetById(long id);

        IQueryable<Conta> GetAll(ContaQuery query);

        bool Remove(ContaRemoveCommand cmd);

        bool UpdateStatus(long id);

        bool Sacar(ContaTransacoesCommand cmd);

        bool Depositar(ContaTransacoesCommand cmd);

        bool Transferir(ContaTransacoesCommand cmd);

        List<Extrato>GetExtratos(int id);
    }
}
