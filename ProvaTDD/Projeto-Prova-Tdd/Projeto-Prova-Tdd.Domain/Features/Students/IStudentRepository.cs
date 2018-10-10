using Projeto_Prova_Tdd.Domain.Base;

namespace Projeto_Prova_Tdd.Domain.Features.Students
{
    public interface IStudentRepository : IRepository<Student>
    {
        bool Exist(string name);

        Student GetByName(string name);

        bool IsTiedTo(long id);
    }
}
