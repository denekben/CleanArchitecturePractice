using CleanArchitecturePractice.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecturePractice.Domain.Policies.Universal
{
    internal sealed class BasicPolicy:IPackingItemsPolicy
    {
        private const uint MaximumQuantityOfClothes = 7;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Pants", Math.Min(data.TravelDays, MaximumQuantityOfClothes)),
                new("T-shirt", 1),
                new("Socks",3)
            };

        public bool IsApplicable(PolicyData _)
            => true;
    }
}
