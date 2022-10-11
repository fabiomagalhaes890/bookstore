namespace Bookstore.Help.Exceptions
{
    public class UpdateException : Exception
    {
        public UpdateException() { }
        public UpdateException(string message) : base(message) { }
        public UpdateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
