using SalaReuniao.Domain.Exceptions;

namespace SalaReuniao.Features.Rooms.Exceptions
{
    public class EmptyNameException : BusinessException
    {
        public EmptyNameException() : base("O NOME não pode ser vazio!")
        {
        }
    }
}
