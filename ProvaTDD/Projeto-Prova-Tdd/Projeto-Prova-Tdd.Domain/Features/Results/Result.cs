using Projeto_Prova_Tdd.Domain.Base;
using Projeto_Prova_Tdd.Domain.Features.Students;
using Projeto_Prova_Tdd.Domain.Features.Results.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Results
{
    public class Result : Entity
    {
        public Student Student { get; set; }
        public double Grade { get; set; }

        public Result(Student student)
        {
            Student = student;
        }

        public override void Validate()
        {
            if (Student == null)
                throw new NoStudentException();

            if (Grade < 0)
                throw new InvalidGradeException();
        }
    }
}
