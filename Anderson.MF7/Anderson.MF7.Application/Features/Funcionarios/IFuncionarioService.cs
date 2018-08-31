using Anderson.MF7.Application.Features.Funcionarios.Commands;
using Anderson.MF7.Application.Features.Funcionarios.Queries;
using Anderson.MF7.Domain.Features.Funcionarios;
using System.Linq;

namespace Anderson.MF7.Application.Features.Funcionarios
{
    public interface IFuncionarioService
    {
        long Add(FuncionarioRegisterCommand cmd);

        bool Update(FuncionarioUpdateCommand cmd);

        Funcionario GetById(long id);

        IQueryable<Funcionario> GetAll(FuncionarioQuery query);

        bool Remove(FuncionarioRemoveCommand cmd);
    }
}
