using SalaReuniao.Exceptions;

namespace SalaReuniao.Features.Employees.Exceptions
{
    public class InvalidBranchLineException : BusinessException
    {
        public InvalidBranchLineException() : base("O RAMAL não pode ser negativo!")
        {
        }
    }
}
