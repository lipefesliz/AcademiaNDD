using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public ContaService(IContaRepository contaRepository, IClienteRepository clienteRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _contaRepository = contaRepository;
            _clienteRepository = clienteRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public long Add(Conta conta)
        {
            conta.Cliente = _clienteRepository.GetbyId(conta.Cliente.Id) ?? throw new NotFoundException();
            var novaConta = _contaRepository.Add(conta);

            return novaConta.Id;
        }

        public IQueryable<Conta> GetAll(int? quantidade = null)
        {
            return _contaRepository.GetAll(quantidade);
        }

        public Conta GetById(long id)
        {
            var conta = _contaRepository.GetbyId(id);

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

        public bool Remove(Conta conta)
        {
            return _contaRepository.Remove(conta.Id);
        }

        public bool Update(Conta conta)
        {
            var contaDb = _contaRepository.GetbyId(conta.Id) ?? throw new NotFoundException();
            var cliente = _clienteRepository.GetbyId(conta.Cliente.Id) ?? throw new NotFoundException();
            var movimentacoes = _movimentacaoRepository.GetAll();
            contaDb.Limite = conta.Limite;
            contaDb.Saldo = conta.Saldo;
            contaDb.Ativada = conta.Ativada;
            contaDb.Cliente = cliente;
            contaDb.Movimentacoes = movimentacoes.ToList();

            return _contaRepository.Update(contaDb);
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

        public bool Sacar(ModeloContaOperacoes conta)
        {
            var contaDb = _contaRepository.GetbyId(conta.ContaOrigemId) ?? throw new NotFoundException();

            contaDb.Sacar(conta.Valor);

            return _contaRepository.Update(contaDb);
        }

        public bool Depositar(ModeloContaOperacoes conta)
        {
            var contaDb = _contaRepository.GetbyId(conta.ContaOrigemId) ?? throw new NotFoundException();

            contaDb.Depositar(conta.Valor);

            return _contaRepository.Update(contaDb);
        }

        public bool Transferir(ModeloContaOperacoes conta)
        {
            if (conta.ContaOrigemId == conta.ContaDestinoId)
                throw new NotAllowedException();

            var contaDb = _contaRepository.GetbyId(conta.ContaOrigemId) ?? throw new NotFoundException();
            var contaDestinoDb = _contaRepository.GetbyId(conta.ContaDestinoId) ?? throw new NotFoundException();

            contaDb.Transferir(conta.Valor, contaDestinoDb);

            _contaRepository.Update(contaDestinoDb);
            return _contaRepository.Update(contaDb);
        }
    }
}
