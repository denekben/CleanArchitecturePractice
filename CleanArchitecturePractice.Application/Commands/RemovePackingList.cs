using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands
{
    public record RemovePackingList(Guid Id) : ICommand;
}
