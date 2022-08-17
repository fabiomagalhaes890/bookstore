using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Bookstore.Application.Books;
using Bookstore.Infrastructure.Base;

namespace Bookstore.Domain.Books
{
    [AutoMap(typeof(BookDto))]
    public class Book : Entity
    {
        [SourceMember(nameof(Book.Name))]
        public virtual string? Name { get; set; }
        [SourceMember(nameof(Book.Price))]
        public virtual decimal Price { get; set; }

        public static Book Create(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("The Book must have name to be registered.");

            if (price <= 0)
                throw new ArgumentException("The Book price must be greather than 0.");

            return new Book()
            {
                Name = name,
                Price = price
            };
        }
    }
}