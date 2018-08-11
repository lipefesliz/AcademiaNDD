using System;

namespace EditoraAcademia.Domain.Exceptions
{
    public class DependenciaException : InvalidOperationException
    {
        public DependenciaException() : base("Esse registro possui depêndecias!")
        {
        }
    }
}
