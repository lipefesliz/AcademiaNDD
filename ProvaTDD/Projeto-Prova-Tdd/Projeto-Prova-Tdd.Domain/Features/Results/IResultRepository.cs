using Projeto_Prova_Tdd.Domain.Base;

namespace Projeto_Prova_Tdd.Domain.Features.Results
{
    public interface IResultRepository : IRepository<Result>
    {
        bool Exist(long id);

        Result GetByStudent(long id);

        bool IsTiedTo(long id);
    }
}
