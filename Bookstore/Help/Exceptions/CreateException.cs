namespace Bookstore.Help.Exceptions
{
    public class CreateException : Exception
    {
        public CreateException() { }
        public CreateException(string message) : base(message) { }
        public CreateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
