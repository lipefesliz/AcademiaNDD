using System;
using System.Runtime.Serialization;

namespace AndersonLiz.Agenda.Doamain.Exceptions
{
    public class HorarioDuplicadoException : ApplicationException
    {
        public HorarioDuplicadoException() : base("Este horário já foi cadastrado!")
        {
        }

        public HorarioDuplicadoException(string message) : base(message)
        {
        }

        public HorarioDuplicadoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HorarioDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
