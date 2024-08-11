using CleanArchitecturePractice.Application.Exceptions;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands.Handlers
{
    public class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _packingListRepository;

        public RemovePackingItemHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(RemovePackingItem command)
        {
            var packingList = await _packingListRepository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            packingList.RemoveItem(command.Name);

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}
