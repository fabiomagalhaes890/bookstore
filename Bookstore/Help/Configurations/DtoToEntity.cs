using AutoMapper;
using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Domain.Books;

namespace Bookstore.Help.Configs
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<BookDto, Book>();
        }
    }
}