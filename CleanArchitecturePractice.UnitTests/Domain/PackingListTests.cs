using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.Events;
using CleanArchitecturePractice.Domain.Exceptions;
using CleanArchitecturePractice.Domain.Factories;
using CleanArchitecturePractice.Domain.Policies;
using CleanArchitecturePractice.Domain.ValueObjects;
using Shouldly;

namespace CleanArchitecturePractice.UnitTests.Domain
{
    public class PackingListTests
    {
        [Fact]
        public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Item_With_The_Same_Name()
        {
            //ARRANGE
            var packingList = GetPackingList();
            packingList.AddItem(new PackingItem("Item 1", 1));

            //ACT
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
        }

        [Fact]
        public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
        {
            //ARRANGE
            var packingList = GetPackingList();

            //ACT
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

            //ASSERT
            exception.ShouldBeNull();
            packingList.Events.Count().ShouldBe(1);
             
            var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

            @event.ShouldNotBeNull();
            @event.PackingItem.Name.ShouldBe("Item 1");
        }

        #region ARRANGE

        private readonly IPackingListFactory _factory;

        private PackingList GetPackingList()
        {
            var packingList = _factory.Create("MyList", Localization.Create("Warsaw, Poland"));
            packingList.ClearEvents();
            return packingList;
        }

        public PackingListTests()
        {
            _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
        }

        #endregion
    }
}
