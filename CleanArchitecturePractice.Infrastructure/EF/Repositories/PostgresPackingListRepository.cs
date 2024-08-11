using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecturePractice.Infrastructure.EF.Repositories
{
    internal sealed class PostgresPackingListRepository : IPackingListRepository
    {
        private readonly DbSet<PackingList> _packingLists;
        private readonly WriteDbContext _writeContext;

        public PostgresPackingListRepository(WriteDbContext writeContext)
        {
            _packingLists = writeContext.PackingLists;
            _writeContext = writeContext;
        }

        public async Task AddAsync(PackingList packingList)
        {
            await _packingLists.AddAsync(packingList);
            await _writeContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PackingList packingList)
        {
            _packingLists.Remove(packingList);
            await _writeContext.SaveChangesAsync();
        }

        public async Task<PackingList> GetAsync(PackingListId id)
        {
            return await _packingLists.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);
        }

        public async Task UpdateAsync(PackingList packingList)
        {
            _packingLists.Update(packingList);
            await _writeContext.SaveChangesAsync();
        }
    }
}
