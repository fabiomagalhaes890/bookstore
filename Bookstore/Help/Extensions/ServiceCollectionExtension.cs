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

            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IRepositoryBase<Book>, BookRepository>();

            return serviceCollection;
        }
    }
}
