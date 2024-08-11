using CleanArchitecturePractice.Application.Services;
using CleanArchitecturePractice.Infrastructure.EF.Contexts;
using CleanArchitecturePractice.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecturePractice.Infrastructure.EF.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public PostgresPackingListReadService(ReadDbContext context)
        {
            _packingLists = context.PackingLists;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _packingLists.AnyAsync(pl=>pl.Name == name);
        }
    }
}
