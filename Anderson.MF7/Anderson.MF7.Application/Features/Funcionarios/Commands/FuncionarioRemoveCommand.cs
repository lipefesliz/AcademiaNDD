using FluentValidation;
using FluentValidation.Results;

namespace Anderson.MF7.Application.Features.Funcionarios.Commands
{
    public class FuncionarioRemoveCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<FuncionarioRemoveCommand>
        {
            public Validator()
            {
                RuleFor(f => f.Id).NotNull().NotEmpty().GreaterThan(0);
            }
        }
    }
}
