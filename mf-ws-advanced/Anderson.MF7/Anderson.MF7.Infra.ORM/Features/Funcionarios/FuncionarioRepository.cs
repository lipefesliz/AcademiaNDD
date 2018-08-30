using Anderson.MF7.Domain.Features.Funcionarios;
using Anderson.MF7.Infra.ORM.Base;
using Anderson.MF7.Infra.ORM.Contexts;

namespace Anderson.MF7.Infra.ORM.Features.Funcionarios
{
    public class FuncionarioRepository : AbstractRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AndersonMF7DbContext context) : base(context)
        {
        }
    }
}
