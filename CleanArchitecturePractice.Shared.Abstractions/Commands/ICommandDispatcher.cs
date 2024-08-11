namespace CleanArchitecturePractice.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        public Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
