using Bookstore.Application.Books.CreateBooks;
using Bookstore.Application.Books.DeleteBooks;
using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Application.Books.UpdateBooks;
using Bookstore.Application.Responses;
using Bookstore.Domain.Books;
using Bookstore.Infrastructure.Base;
using Bookstore.Infrastructure.Repositories;
using Bookstore.Infrastructure.Repositories.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookstore.Help.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, BookstoreContext>();

            // services


            // repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRepositoryBase<Book>, BookRepository>();

            // mediator 
            services.AddMediatR(typeof(CreateBookCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetBooksQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetBookDetailsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateBookCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteBookCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
