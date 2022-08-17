using System.Data;

namespace Bookstore.Infrastructure.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
