using CleanArchitecturePractice.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecturePractice.Domain.Policies.Temperature
{
    internal sealed class HighTemperaturePolicy:IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Limonade", 1),
                new("Ice", 10),
                new("Show",1)
            };

        public bool IsApplicable(PolicyData data)
            => data.Temperature > 30D;
    }
}
