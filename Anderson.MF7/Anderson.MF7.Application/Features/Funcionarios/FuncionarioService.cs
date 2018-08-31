using Anderson.MF7.Application.Features.Funcionarios.Commands;
using Anderson.MF7.Application.Features.Funcionarios.Queries;
using Anderson.MF7.Domain.Exceptions;
using Anderson.MF7.Domain.Features.Funcionarios;
using AutoMapper;
using System.Linq;

namespace Anderson.MF7.Application.Features.Funcionarios
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public long Add(FuncionarioRegisterCommand cmd)
        {
            var funcionario = Mapper.Map<FuncionarioRegisterCommand, Funcionario>(cmd);

            var novoFuncionario = _funcionarioRepository.Add(funcionario);

            return novoFuncionario.Id;
        }

        public IQueryable<Funcionario> GetAll(FuncionarioQuery query)
        {
            if (query == null)
                return _funcionarioRepository.GetAll(null);

            return _funcionarioRepository.GetAll(query.Quantity);
        }

        public Funcionario GetById(long id)
        {
            var funcionario = _funcionarioRepository.GetbyId(id) ?? throw new NotFoundException();

            return funcionario;
        }

        public bool Remove(FuncionarioRemoveCommand cmd)
        {
            var funcionarioDb = _funcionarioRepository.GetbyId(cmd.Id) ?? throw new NotFoundException();

            return _funcionarioRepository.Remove(funcionarioDb.Id);
        }

        public bool Update(FuncionarioUpdateCommand cmd)
        {
            var funcionarioDb = _funcionarioRepository.GetbyId(cmd.Id) ?? throw new NotFoundException();

            var funcionario = Mapper.Map(cmd, funcionarioDb);

            return _funcionarioRepository.Update(funcionario);
        }
    }
}
