using System;

namespace AndersonLiz.Agenda.Doamain.Exceptions
{
    public class DependenciaException : InvalidOperationException
    {
        public DependenciaException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
