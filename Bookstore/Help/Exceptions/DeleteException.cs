namespace Bookstore.Help.Exceptions
{
    public class DeleteException : Exception
    {
        public DeleteException() { }
        public DeleteException(string message) : base(message) { }
        public DeleteException(string message, Exception innerException) : base(message, innerException) { }
    }
}
