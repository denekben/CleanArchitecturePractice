namespace CleanArchitecturePractice.Shared.Abstractions.Commands
{
    public interface ICommandHandler<in Tcommand> where Tcommand : class, ICommand
    {
        public Task HandleAsync(Tcommand command);
    }
}
