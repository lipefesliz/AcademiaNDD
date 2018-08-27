using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Application.Features.Usuarios.Commands
{
    public class UsuarioRemoveCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<UsuarioRemoveCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
            }
        }
    }
}
