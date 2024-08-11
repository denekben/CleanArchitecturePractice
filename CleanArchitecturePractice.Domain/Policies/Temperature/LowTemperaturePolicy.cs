using CleanArchitecturePractice.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecturePractice.Domain.Policies.Temperature
{
    internal sealed class LowTemperaturePolicy:IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Winter Hat", 1),
                new("Scarf", 1),
            };

        public bool IsApplicable(PolicyData data)
            => data.Temperature < 10D;
    }
}
