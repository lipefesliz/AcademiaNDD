using BancoTabajara.Domain.Features.Movimentacoes;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace BancoTabajara.Application.Features.Contas.Commands
{
    public class ContaUpdateCommand
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public double Limite { get; set; }
        public double Saldo { get; set; }
        public double SaldoTotal { get { return Limite + Saldo; } }
        public bool Ativada { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<ContaUpdateCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Saldo).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.Ativada).NotNull();
                RuleFor(c => c.Limite).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.Numero).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.SaldoTotal).NotNull();
                RuleForEach(c => c.Movimentacoes).NotNull();
            }
        }
    }
}
