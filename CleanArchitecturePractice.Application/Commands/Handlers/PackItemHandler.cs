using CleanArchitecturePractice.Application.Exceptions;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands.Handlers
{
    public class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _packingListRepository;

        public PackItemHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(PackItem command)
        {
            var packingList = await _packingListRepository.GetAsync(command.PackingListId);

            if(packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            packingList.PackItem(command.Name);

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}
