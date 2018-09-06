using Anderson.MF7.Domain.Exceptions;
using Anderson.MF7.Domain.Features.Funcionarios;
using Anderson.MF7.Infra.ORM.Base;
using Anderson.MF7.Infra.ORM.Contexts;
using System.Linq;

namespace Anderson.MF7.Infra.ORM.Features.Funcionarios
{
    public class FuncionarioRepository : AbstractRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AndersonMF7DbContext context) : base(context)
        {
        }

        public Funcionario GetByCredentials(string username, string password)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Usuario.Equals(username) && f.Senha == password) ?? throw new InvalidCredentialsException();

            return funcionario;
        }
    }
}
