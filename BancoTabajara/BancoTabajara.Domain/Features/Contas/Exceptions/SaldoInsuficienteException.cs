using BancoTabajara.Domain.Exceptions;

namespace BancoTabajara.Domain.Features.Contas.Exceptions
{
    public class SaldoInsuficienteException : BusinessException
    {
        public SaldoInsuficienteException() : base(ErrorCodes.NotAllowed, "Saldo insuficiente")
        {
        }
    }
}
