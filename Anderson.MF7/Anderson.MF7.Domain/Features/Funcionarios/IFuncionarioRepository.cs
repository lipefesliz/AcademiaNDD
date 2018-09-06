using Anderson.MF7.Domain.Base;

namespace Anderson.MF7.Domain.Features.Funcionarios
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Funcionario GetByCredentials(string username, string password);
    }
}
