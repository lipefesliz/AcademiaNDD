using System;

namespace BancoTabajara.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public ErrorCodes ErrorCode { get; }

        public BusinessException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
