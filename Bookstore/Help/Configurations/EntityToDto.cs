using AutoMapper;
using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Domain.Books;

namespace Bookstore.Help.Configs
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Book, BookDto>();
        }
    }
}