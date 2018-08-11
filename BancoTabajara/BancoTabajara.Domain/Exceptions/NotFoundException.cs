namespace BancoTabajara.Domain.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException() : base(ErrorCodes.NotFound, "Registry not found")
        {
        }
    }
}
