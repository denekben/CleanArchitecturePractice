using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands
{
    public record AddPackingItem(Guid PackingListId, string Name, uint Quantity) : ICommand;
}
