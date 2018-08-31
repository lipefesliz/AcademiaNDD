using Anderson.MF7.Domain.Features.Gastos;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace Anderson.MF7.Application.Features.Gastos.Commands
{
    public class GastoRegisterCommand
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public TipoGastoEnum Tipo { get; set; }
        public int FuncionarioID { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<GastoRegisterCommand>
        {
            public Validator()
            {
                RuleFor(g => g.Descricao).MaximumLength(100).NotNull();
                RuleFor(g => g.Data).NotNull().NotEmpty();
                RuleFor(g => g.Preco).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(g => g.Tipo).NotNull();
                RuleFor(g => g.FuncionarioID).NotNull().GreaterThan(0);
            }
        }
    }
}
