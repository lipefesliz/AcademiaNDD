﻿namespace SalaReuniao.Domain.Exceptions
{
    public class TiedException : BusinessException
    {
        public TiedException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
