namespace Bookstore.Help.Configurations.Commands
{
    public class CommandBase : ICommand
    {
        public Guid Id { get; }

        public CommandBase()
        {
            Id = Guid.NewGuid();
        }

        public CommandBase(Guid id)
        {
            Id = id;
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        public CommandBase()
        {
            Id = Guid.NewGuid();
        }

        public CommandBase(Guid id)
        {
            Id = id;
        }
    }
}
