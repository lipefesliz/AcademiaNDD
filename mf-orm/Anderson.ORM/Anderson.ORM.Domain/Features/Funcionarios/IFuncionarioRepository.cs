using Anderson.ORM.Domain.Base;
using Anderson.ORM.Domain.Features.Cargos;
using System.Collections.Generic;

namespace Anderson.ORM.Domain.Features.Funcionarios
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        ICollection<Funcionario> ObterPorCargo(string cargo);
    }
}
