namespace MediaProva.Domain.Exceptions
{
    public class DuplicatedNameException : BusinessException
    {
        public DuplicatedNameException(string message) : base(message)
        {
        }
    }
}
