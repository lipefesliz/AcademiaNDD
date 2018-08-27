using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Application.Features.Usuarios.Commands
{
    public class UsuarioUpdateCommand
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<UsuarioUpdateCommand>
        {
            public Validator()
            {
                RuleFor(u => u.Id).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(u => u.Nome).NotNull().Length(1, 100);
                RuleFor(u => u.Senha).NotNull().Length(1, 1000);
            }
        }
    }
}
