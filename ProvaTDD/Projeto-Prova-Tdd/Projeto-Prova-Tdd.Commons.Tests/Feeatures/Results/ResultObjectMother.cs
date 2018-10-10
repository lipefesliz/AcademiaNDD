using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Students;
using Projeto_Prova_Tdd.Domain.Features.Results;
using Projeto_Prova_Tdd.Domain.Features.Students;

namespace Projeto_Prova_Tdd.Commons.Tests.Feeatures.Results
{
    public class ResultObjectMother
    {
        private static Student student = StudentObjectMother.CreateValidStudent();

        public static Result CreateValidResult()
        {
            return new Result(student)
            {
                Id = 1,
                Student = student,
                Grade = 10.0
            };
        }
    }
}
