using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Domain.Policies.Gender
{
    internal sealed class MaleGenderPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Book", 1),
                new("Beer", 10),
                new("Laptop",1)
            };

        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Male;
    }
}
