using System;
using Projeto_Prova_Tdd.Domain.Base;
using Projeto_Prova_Tdd.Domain.Features.Students.Exceptions;

namespace Projeto_Prova_Tdd.Domain.Features.Students
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void CalculateAverage()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Name))
                throw new NoNameException();
        }
    }
}
