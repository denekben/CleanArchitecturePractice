using CleanArchitecturePractice.Application.DTO;
using CleanArchitecturePractice.Application.Queries;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Infrastructure.EF.Contexts;
using CleanArchitecturePractice.Infrastructure.EF.Models;
using CleanArchitecturePractice.Infrastructure.EF.Queries;
using CleanArchitecturePractice.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecturePractice.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public GetPackingListHandler(ReadDbContext context)
        {
            _packingLists = context.PackingLists;
        }

        public async Task<PackingListDto> HandleAsync(GetPackingList query)
        {
            return await _packingLists
                .Include(pl => pl.Items)
                .Where(pl => pl.Id == query.Id)
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
            
    }
}
