using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Bookstore.Domain.Books;
using Bookstore.Infrastructure.Models;

namespace Bookstore.Application.Books
{
    [AutoMap(typeof(Book))]
    public class BookDto : Model
    {
        [SourceMember(nameof(Book.Name))]
        public string? Name { get; set; }
        [SourceMember(nameof(Book.Price))]
        public decimal Price { get; set; }
    }
}