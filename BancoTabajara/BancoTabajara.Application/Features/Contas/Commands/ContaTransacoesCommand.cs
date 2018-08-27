using BancoTabajara.Domain.Features.Movimentacoes;
using FluentValidation;
using FluentValidation.Results;

namespace BancoTabajara.Application.Features.Contas.Commands
{
    public class ContaTransacoesCommand
    {
        public int ContaOrigemId { get; set; }
        public int ContaDestinoId { get; set; }
        public double Valor { get; set; }

        public virtual ValidationResult Validate(TipoMovimentacaoEnum tipoOperacao)
        {
            return new Validator(tipoOperacao).Validate(this);
        }

        private class Validator : AbstractValidator<ContaTransacoesCommand>
        {
            public Validator(TipoMovimentacaoEnum tipoOperacao)
            {
                RuleFor(c => c.Valor).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(c => c.ContaOrigemId).NotNull().NotEmpty().GreaterThan(0);
                if (tipoOperacao == TipoMovimentacaoEnum.TRANSFERENCIA)
                {
                    RuleFor(c => c.ContaDestinoId).NotNull().NotEmpty().GreaterThan(0);
                }
            }
        }
    }
}
