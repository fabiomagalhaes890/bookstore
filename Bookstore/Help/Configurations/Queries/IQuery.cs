using MediatR;

namespace Bookstore.Help.Configurations.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
