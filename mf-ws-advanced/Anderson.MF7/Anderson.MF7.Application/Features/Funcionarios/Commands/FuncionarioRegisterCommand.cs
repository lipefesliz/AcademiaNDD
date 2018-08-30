using FluentValidation;
using FluentValidation.Results;

namespace Anderson.MF7.Application.Features.Funcionarios.Commands
{
    public class FuncionarioRegisterCommand
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public string Cargo { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<FuncionarioRegisterCommand>
        {
            public Validator()
            {
                RuleFor(f => f.Nome).MaximumLength(50).NotNull();
                RuleFor(f => f.Sobrenome).MaximumLength(50).NotNull();
                RuleFor(f => f.Usuario).MaximumLength(20).NotNull();
                RuleFor(f => f.Senha).MaximumLength(8).NotNull();
                RuleFor(f => f.Ativo).NotNull();
                RuleFor(f => f.Cargo).MaximumLength(30).NotNull();
            }
        }
    }
}
