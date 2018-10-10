using Projeto_Prova_Tdd.Domain.Features.Students;

namespace Projeto_Prova_Tdd.Commons.Tests.Feeatures.Students
{
    public static partial class StudentObjectMother
    {
        public static Student CreateValidStudent()
        {
            return new Student
            {
                Id = 1,
                Name = "Felipe",
                Age = 32
            };
        }
    }
}
