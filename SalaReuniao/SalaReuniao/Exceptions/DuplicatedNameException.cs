using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Domain.Exceptions
{
    public class DuplicatedNameException : BusinessException
    {
        public DuplicatedNameException() : base("Este nome já foi cadastrado!")
        {
        }
    }
}
