using AutoMapper;
using Bookstore.Application.Responses;
using Bookstore.Domain.Books;

namespace Bookstore.Help.Configs
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Book, BookResponse>();
        }
    }
}