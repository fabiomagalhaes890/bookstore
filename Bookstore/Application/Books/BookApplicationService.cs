﻿using Bookstore.Domain.Books;
using Bookstore.Infrastructure.Repositories;

namespace Bookstore.Application.Books
{
    public class BookApplicationService : ApplicationServiceBase<BookDto, Book>, IBookApplicationService
    {
        public BookApplicationService(IRepositoryBase<Book> repositoryBase) : base(repositoryBase)
        {
        }
    }
}