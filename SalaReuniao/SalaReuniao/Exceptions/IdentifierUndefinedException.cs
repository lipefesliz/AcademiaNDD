namespace SalaReuniao.Domain.Exceptions
{
    public class IdentifierUndefinedException : BusinessException
    {
        public IdentifierUndefinedException() : base("O ID não pode ser vazio!")
        {
        }
    }
}
