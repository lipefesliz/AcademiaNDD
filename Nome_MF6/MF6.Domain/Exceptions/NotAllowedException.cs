namespace MF6.Domain.Exceptions
{
    public class NotAllowedException : BusinessException
    {
        public NotAllowedException() : base(ErrorCodes.NotAllowed, "Operation not allowed")
        {
        }
    }
}
