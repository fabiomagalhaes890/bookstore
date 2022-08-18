using Bookstore.Application;
using Bookstore.Application.Books;
using Bookstore.Domain.Books;
using Bookstore.Infrastructure.Base;
using Bookstore.Infrastructure.Repositories;
using Bookstore.Infrastructure.Repositories.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Help.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DbContext, BookstoreContext>();

            // services
            serviceCollection.AddScoped<IBookApplicationService, BookApplicationService>();
            serviceCollection.AddScoped<IApplicationServiceBase<BookDto, Book>, BookApplicationService>();

            // repositories
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IRepositoryBase<Book>, BookRepository>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(cfg => cfg.AddMaps(typeof(Book).Assembly, typeof(BookDto).Assembly));

            return serviceCollection;
        }
    }
}
