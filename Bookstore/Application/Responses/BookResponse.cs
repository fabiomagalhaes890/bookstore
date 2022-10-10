using Bookstore.Infrastructure.Models;

namespace Bookstore.Application.Responses
{
    public class BookResponse : Model
    {
        public BookResponse(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
