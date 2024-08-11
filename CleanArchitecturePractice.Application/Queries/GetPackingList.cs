using CleanArchitecturePractice.Application.DTO;
using CleanArchitecturePractice.Shared.Abstractions.Queries;

namespace CleanArchitecturePractice.Application.Queries
{
    public class GetPackingList : IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
}
