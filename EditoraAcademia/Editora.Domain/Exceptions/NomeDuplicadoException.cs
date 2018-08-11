using System;
using System.Runtime.Serialization;

namespace EditoraAcademia.Domain.Exceptions
{
    public class NomeDuplicadoException : ApplicationException
    {
        public NomeDuplicadoException() : base("Este nome já foi cadastrado!")
        {
        }

        public NomeDuplicadoException(string message) : base(message)
        {
        }

        public NomeDuplicadoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NomeDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
