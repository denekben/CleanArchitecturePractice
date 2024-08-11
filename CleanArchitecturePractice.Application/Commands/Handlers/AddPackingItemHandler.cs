using CleanArchitecturePractice.Application.Exceptions;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands.Handlers
{
    public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _packingListRepository;

        public AddPackingItemHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(AddPackingItem command)
        {
            var packingList = await _packingListRepository.GetAsync(command.PackingListId);

            if(packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}
