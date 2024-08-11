using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands
{
    public record PackItem(Guid PackingListId, string Name) : ICommand;
}
