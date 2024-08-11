using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands
{
    public record RemovePackingItem(Guid PackingListId, string Name) : ICommand;
}
