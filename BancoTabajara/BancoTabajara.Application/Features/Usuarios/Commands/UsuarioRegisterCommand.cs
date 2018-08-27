using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Application.Features.Usuarios.Commands
{
    public class UsuarioRegisterCommand
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<UsuarioRegisterCommand>
        {
            public Validator()
            {
                RuleFor(u => u.Nome).NotNull().Length(1, 50);
                RuleFor(u => u.Senha).NotNull().Length(1, 8);
            }
        }
    }
}
