using CleanArchitecturePractice.Domain.Events;
using CleanArchitecturePractice.Domain.Exceptions;
using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Shared.Abstractions.Domain;

namespace CleanArchitecturePractice.Domain.Entities
{
    public class PackingList:AggregateRoot<Guid>
    {
        public PackingListId Id { get; private set; }

        private PackingListName _name;
        private Localization _localization;

        private readonly LinkedList<PackingItem> _items = new(); 
     
        private PackingList(PackingListName name, Localization localization, LinkedList<PackingItem> items)
            : this (name, localization)
        {
            AddItems(items);
        }

        private PackingList()
        {
        }

        internal PackingList(PackingListName name, Localization localization)
        {
            _name = name;
            _localization = localization;
        }

        public void AddItem(PackingItem item)
        {
            var alreadyExists = _items.Any(i=>i.Name == item.Name);
            
            if(alreadyExists)
            {
                throw new PackingItemAlreadyExistsException(_name, item.Name);
            }

            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach(var item in items)
            {
                AddItem(item);
            }
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };

            _items.Find(item).Value = packedItem;
            AddEvent(new PackingItemPacked(this, packedItem));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);

            _items.Remove(item);
            AddEvent(new PackingItemRemoved(this, item));
        }

        public PackingItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i=>i.Name==itemName);

            if(item is null)
            {
                throw new PackingItemNotFoundException(itemName);
            }

            return item;
        }
    }
}
