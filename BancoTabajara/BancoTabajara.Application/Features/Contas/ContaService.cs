using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BancoTabajara.Application.Features.Contas.Commands;
using BancoTabajara.Application.Features.Contas.Queries;
using BancoTabajara.Domain.Exceptions;
using BancoTabajara.Domain.Features.Clientes;
using BancoTabajara.Domain.Features.Contas;
using BancoTabajara.Domain.Features.Movimentacoes;

namespace BancoTabajara.Application.Features.Contas
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IClienteRepository _clienteRepository;

        public ContaService(IContaRepository contaRepository, IClienteRepository clienteRepository)
        {
            _contaRepository = contaRepository;
            _clienteRepository = clienteRepository;
        }

        public long Add(ContaRegisterCommand cmd)
        {
            var conta = Mapper.Map<ContaRegisterCommand, Conta>(cmd);

            conta.Cliente = _clienteRepository.GetbyId(cmd.Cliente.Id) ?? throw new NotFoundException();

            var novaConta = _contaRepository.Add(conta);

            return novaConta.Id;
        }

        public IQueryable<Conta> GetAll(ContaQuery query)
        {
            if (query == null)
                return _contaRepository.GetAll(null);

            return _contaRepository.GetAll(query.Quantity);
        }

        public Conta GetById(long id)
        {
            var conta = _contaRepository.GetbyId(id) ?? throw new NotFoundException();

            return conta;
        }

        public List<Extrato> GetExtratos(int id)
        {
            var conta = _contaRepository.GetbyId(id) ?? throw new NotFoundException();

            var extratos = new List<Extrato>();

            for (int i = 0; i < conta.Movimentacoes.Count(); i++)
            {
                var extrato = new Extrato();
                extrato.NumeroConta = conta.Numero;
                extrato.Titular = conta.Cliente.Nome;
                extrato.Data = DateTime.Now;
                if (conta.Movimentacoes.ElementAt(i).Tipo == TipoMovimentacaoEnum.CREDITO)
                    extrato.Credito = conta.Movimentacoes.ElementAt(i).Valor;
                else
                    extrato.Debito = conta.Movimentacoes.ElementAt(i).Valor;
                extratos.Add(extrato);
            }
            
            return extratos;
        }

        public bool Remove(ContaRemoveCommand cmd)
        {
            var contaDb = _contaRepository.GetbyId(cmd.Id) ?? throw new NotFoundException();

            return _contaRepository.Remove(contaDb.Id);
        }

        public bool Update(ContaUpdateCommand cmd)
        {
            var contaDb = _contaRepository.GetbyId(cmd.Id) ?? throw new NotFoundException();

            var conta = Mapper.Map(cmd, contaDb);

            return _contaRepository.Update(conta);
        }

        public bool UpdateStatus(long id)
        {   
            var conta = _contaRepository.GetbyId(id) ?? throw new NotFoundException();

            if (conta.Ativada)
                conta.Ativada = false;
            else
                conta.Ativada = true;

            return _contaRepository.Update(conta);
        }

        public bool Sacar(ContaTransacoesCommand cmd)
        {
            var contaDb = _contaRepository.GetbyId(cmd.ContaOrigemId) ?? throw new NotFoundException();

            contaDb.Sacar(cmd.Valor);

            return _contaRepository.Update(contaDb);
        }

        public bool Depositar(ContaTransacoesCommand cmd)
        {
            var contaDb = _contaRepository.GetbyId(cmd.ContaOrigemId) ?? throw new NotFoundException();

            contaDb.Depositar(cmd.Valor);

            return _contaRepository.Update(contaDb);
        }

        public bool Transferir(ContaTransacoesCommand cmd)
        {
            if (cmd.ContaOrigemId == cmd.ContaDestinoId)
                throw new NotAllowedException();

            var contaDb = _contaRepository.GetbyId(cmd.ContaOrigemId) ?? throw new NotFoundException();
            var contaDestinoDb = _contaRepository.GetbyId(cmd.ContaDestinoId) ?? throw new NotFoundException();

            contaDb.Transferir(cmd.Valor, contaDestinoDb);

            _contaRepository.Update(contaDestinoDb);
            return _contaRepository.Update(contaDb);
        }
    }
}
