using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Application.Features.Contas.Commands
{
    public class ContaRemoveCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<ContaRemoveCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
            }
        }
    }
}
