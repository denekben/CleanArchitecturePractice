using CleanArchitecturePractice.Domain.Consts;
using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands
{
    public record CreatePackingListWithItems(string Name, ushort Days,
        Gender Gender, LocalizationWriteModel Localization) : ICommand;

    public record LocalizationWriteModel(string City, string Country);
    
}
