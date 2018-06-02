using SalaReuniao.Domain.Base;
using SalaReuniao.Features.Employees.Exceptions;
using System;

namespace SalaReuniao.Domain.Features.Employees
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Post { get; set; }
        public int BranchLine { get; set; }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Name))
                throw new NameIsNullOrEmptyException();

            if (String.IsNullOrEmpty(Post))
                throw new PostIsNullOrEmptyException();

            if (BranchLine < 1)
                throw new InvalidBranchLineException();
        }
    }
}
