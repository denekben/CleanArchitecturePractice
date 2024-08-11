using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Domain.Exceptions
{
    public class PackingItemAlreadyExistsException : PackItException
    {
        public string ListItem { get; }
        public string ItemName { get; }

        public PackingItemAlreadyExistsException(string listName, string itemName) 
            : base($"Packing list: '{listName}' already defined item {itemName}.")
        { 
            ListItem = listName;
            ItemName = itemName;
        }
    }
}