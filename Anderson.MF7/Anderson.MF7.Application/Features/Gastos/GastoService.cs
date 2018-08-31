using Anderson.MF7.Application.Features.Gastos.Commands;
using Anderson.MF7.Application.Features.Gastos.Queries;
using Anderson.MF7.Domain.Exceptions;
using Anderson.MF7.Domain.Features.Funcionarios;
using Anderson.MF7.Domain.Features.Gastos;
using AutoMapper;
using System.Linq;

namespace Anderson.MF7.Application.Features.Gastos
{
    public class GastoService : IGastoService
    {
        private IGastoRepository _gastoRepository;
        private IFuncionarioRepository _funcionarioRepository;

        public GastoService(IGastoRepository gastoRepository, IFuncionarioRepository funcionarioRepository)
        {
            _gastoRepository = gastoRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public long Add(GastoRegisterCommand cmd)
        {
            var gasto = Mapper.Map<GastoRegisterCommand, Gasto>(cmd);

            gasto.Funcionario = _funcionarioRepository.GetbyId(cmd.FuncionarioID) ?? throw new NotFoundException();

            var novoGasto = _gastoRepository.Add(gasto);

            return novoGasto.Id;
        }

        public IQueryable<Gasto> GetAll(GastoQuery query)
        {
            if (query == null)
                return _gastoRepository.GetAll(null);

            return _gastoRepository.GetAll(query.Quantity);
        }

        public Gasto GetById(long id)
        {
            var gasto = _gastoRepository.GetbyId(id) ?? throw new NotFoundException();

            return gasto;
        }

        public bool Remove(GastoRemoveCommand cmd)
        {
            var gastoDb = _gastoRepository.GetbyId(cmd.Id) ?? throw new NotFoundException();

            return _gastoRepository.Remove(gastoDb.Id);
        }
    }
}
