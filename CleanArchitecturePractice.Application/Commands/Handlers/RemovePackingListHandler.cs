using CleanArchitecturePractice.Application.Exceptions;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands.Handlers
{
    public class RemovePackingListHandler : ICommandHandler<RemovePackingList>
    {
        private readonly IPackingListRepository _packingListRepository;

        public RemovePackingListHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(RemovePackingList command)
        {
            var packingList = await _packingListRepository.GetAsync(command.Id);

            if(packingList is null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            await _packingListRepository.DeleteAsync(packingList);
        }
    }
}
