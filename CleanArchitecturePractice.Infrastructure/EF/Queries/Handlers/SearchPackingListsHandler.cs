using CleanArchitecturePractice.Application.DTO;
using CleanArchitecturePractice.Application.Queries;
using CleanArchitecturePractice.Infrastructure.EF.Contexts;
using CleanArchitecturePractice.Infrastructure.EF.Models;
using CleanArchitecturePractice.Infrastructure.EF.Queries;
using CleanArchitecturePractice.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecturePractice.Infrastructure.EF.Queries.Handlers
{
    internal sealed class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public SearchPackingListsHandler(ReadDbContext context)
        {
            _packingLists = context.PackingLists;
        }

        public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
            var dbQuery = _packingLists
                .Include(pl => pl.Items)
                .AsQueryable();

            if (query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(pl =>
                    Microsoft.EntityFrameworkCore.EF.Functions.ILike(pl.Name, $"%{query.SearchPhrase}%"));
            }

            return await dbQuery
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
