using Bookstore.Help.Configurations.Commands;

namespace Bookstore.Application.Books.DeleteBooks
{
    public class DeleteBookCommand : CommandBase
    {
        public Guid BookId { get; set; }

        public DeleteBookCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
