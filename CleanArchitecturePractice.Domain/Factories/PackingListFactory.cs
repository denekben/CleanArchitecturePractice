using CleanArchitecturePractice.Domain.Consts;
using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.Policies;
using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Domain.Factories
{
    public sealed class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemsPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
            => _policies = policies;
        
        public PackingList Create(PackingListName name, Localization localization)
            => new(name, localization);

        public PackingList CreateWithDefaultItems(PackingListName name, 
            TravelDays days, Gender gender, Temperature temperature, Localization localization)
        {
            var data = new PolicyData(days, gender, temperature, localization);
            var applicablePolicies = _policies.Where(p=>p.IsApplicable(data));

            var items = applicablePolicies.SelectMany(p=>p.GenerateItems(data));
            var packingList = Create(name, localization);

            packingList.AddItems(items);

            return packingList;
        }
    }
}
