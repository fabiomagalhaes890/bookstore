using AutoMapper;
using Bookstore.Application.Books.CreateBooks;
using Bookstore.Application.Responses;
using Bookstore.Domain.Books;

namespace Bookstore.Help.Configs
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<BookResponse, Book>();
            CreateMap<CreateBookCommand, Book>();
        }
    }
}