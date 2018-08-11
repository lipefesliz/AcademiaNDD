using BancoTabajara.Domain.Exceptions;

namespace BancoTabajara.Domain.Features.Contas.Exceptions
{
    public class ContaDesativadaException : BusinessException
    {
        public ContaDesativadaException() : base(ErrorCodes.NotAllowed, "Conta inativa")
        {
        }
    }
}
