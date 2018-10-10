using Anderson.ORM.Domain.Base;
using System.Collections.Generic;

namespace Anderson.ORM.Domain.Features.Dependentes
{
    public interface IDependenteRepository : IRepository<Dependente>
    {
        ICollection<Dependente> ObterPorFuncionario(string funcionario);
    }
}
