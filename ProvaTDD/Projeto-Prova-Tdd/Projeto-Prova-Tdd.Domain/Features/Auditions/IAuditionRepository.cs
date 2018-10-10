using Projeto_Prova_Tdd.Domain.Base;

namespace Projeto_Prova_Tdd.Domain.Features.Auditions
{
    public interface IAuditionRepository : IRepository<Audition>
    {
        bool Exist(string theme);

        Audition GetByAudition(string theme);
    }
}
