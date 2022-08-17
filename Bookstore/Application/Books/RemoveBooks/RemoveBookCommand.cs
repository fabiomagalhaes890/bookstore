using Bookstore.Help.Configurations.Commands;

namespace Bookstore.Application.Books.RemoveBooks
{
    public class RemoveBookCommand : CommandBase
    {
        public Guid BookId { get; set; }

        public RemoveBookCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
