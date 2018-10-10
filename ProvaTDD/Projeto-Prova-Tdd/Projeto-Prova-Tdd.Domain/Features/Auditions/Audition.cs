using System;
using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Base;
using Projeto_Prova_Tdd.Domain.Features.Results;
using Projeto_Prova_Tdd.Domain.Features.Auditions.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Auditions
{
    public class Audition : Entity
    {
        public string Theme { get; set; }
        public DateTime Date { get; set; }
        public List<Result> Results { get; set; }

        public override void Validate()
        {
            if (Results.Count < 1)
                throw new NoResultsException();
        }
    }
}
