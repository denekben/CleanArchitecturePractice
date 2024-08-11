using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Domain.Policies.Gender
{
    internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Lipstick", 1),
                new("Eyeliner", 10),
                new("Laptop",1)
            };

        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Female;
    }
}
