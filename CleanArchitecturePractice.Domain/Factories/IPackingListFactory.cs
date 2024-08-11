using CleanArchitecturePractice.Domain.Consts;
using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Domain.Factories
{
    public interface IPackingListFactory
    {
        PackingList Create(PackingListName name, Localization localization);
        PackingList CreateWithDefaultItems(PackingListName name, TravelDays days, Gender gender, 
            Temperature temperature, Localization localization);
    }
}
