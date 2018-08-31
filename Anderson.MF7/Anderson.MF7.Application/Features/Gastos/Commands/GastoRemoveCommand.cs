using FluentValidation;
using FluentValidation.Results;

namespace Anderson.MF7.Application.Features.Gastos.Commands
{
    public class GastoRemoveCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<GastoRemoveCommand>
        {
            public Validator()
            {
                RuleFor(g => g.Id).NotNull().NotEmpty().GreaterThan(0);
            }
        }
    }
}
