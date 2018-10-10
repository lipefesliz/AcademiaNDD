using Projeto_Prova_Tdd.Domain.Features.Auditions;
using System;
using Projeto_Prova_Tdd.Domain.Features.Results;
using System.Collections.Generic;
using Projeto_Prova_Tdd.Commons.Tests.Feeatures.Results;

namespace Projeto_Prova_Tdd.Commons.Tests.Feeatures.Auditions
{
    public class AuditionObjectMother
    {
        private static Result result = ResultObjectMother.CreateValidResult();

        public static Audition CreateValidAudition()
        {
            return new Audition()
            {
                Id = 1,
                Theme = "TDD",
                Date = DateTime.Now,
                Results = new List<Result> { result }
            };
        }
    }
}
