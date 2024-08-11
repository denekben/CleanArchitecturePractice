using CleanArchitecturePractice.Application.DTO;
using CleanArchitecturePractice.Shared.Abstractions.Queries;

namespace CleanArchitecturePractice.Application.Queries
{
    public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
