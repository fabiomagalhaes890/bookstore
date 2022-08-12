using AutoMapper;
using Bookstore.Application.Books;
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