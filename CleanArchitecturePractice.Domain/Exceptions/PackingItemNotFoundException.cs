using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackItException
    {
        public string ItemName { get; }
        public PackingItemNotFoundException(string itemName) : base($"Packing item '{itemName}' not found.")
        {
            ItemName = itemName;
        }
    }
}
