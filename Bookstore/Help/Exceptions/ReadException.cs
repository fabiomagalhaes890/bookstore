namespace Bookstore.Help.Exceptions
{
    public class ReadException : Exception
    {
        public ReadException() { }
        public ReadException(string message) : base(message) { }
        public ReadException(string message, Exception innerException) : base(message, innerException) { }
    }
}
