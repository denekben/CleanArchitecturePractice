using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Domain.Repositories
{
    public interface IPackingListRepository
    {
        Task<PackingList> GetAsync(PackingListId id);
        Task AddAsync(PackingList packingList);
        Task UpdateAsync(PackingList packingList);
        Task DeleteAsync(PackingList packingList);

    }
}
