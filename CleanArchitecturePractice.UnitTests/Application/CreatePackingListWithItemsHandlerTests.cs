using CleanArchitecturePractice.Application.Commands;
using CleanArchitecturePractice.Application.Commands.Handlers;
using CleanArchitecturePractice.Application.DTO.External;
using CleanArchitecturePractice.Application.Exceptions;
using CleanArchitecturePractice.Application.Services;
using CleanArchitecturePractice.Domain.Consts;
using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.Factories;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Shared.Abstractions.Commands;
using NSubstitute;
using Shouldly;

namespace CleanArchitecturePractice.UnitTests.Application
{
    public class CreatePackingListWithItemsHandlerTests
    {
        async Task Act(CreatePackingListWithItems command)
        {
            await _commandHandler.HandleAsync(command);
        }

        [Fact]
        public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_Same_Name_Already_Exists()
        {
            //ARRANGE
            var command = new CreatePackingListWithItems("MyList", 10, Gender.Female, default);
            _readService.ExistsByNameAsync(command.Name).Returns(true);

            //ACT
            var exception = Record.ExceptionAsync(() => Act(command));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListAlreadyExistsException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_Weather_Was_Not_Return()
        {
            //ARRANGE
            var command = new CreatePackingListWithItems("MyList", 10, Gender.Female, 
                new LocalizationWriteModel("Warsaw", "Poland"));

            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDto));

            //ACT
            var exception = await Record.ExceptionAsync(() => Act(command));
        
            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingLocalizationWeatherException>();
        }

        [Fact]
        public async Task HamdleAsync_Calls_Repository_On_Success()
        {
            //ARRANGE
            var command = new CreatePackingListWithItems("MyList", 10, Gender.Female,
                new LocalizationWriteModel("Warsaw", "Poland"));

            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDto(12));
            _factory.CreateWithDefaultItems(command.Name, command.Days, command.Gender, Arg.Any<Temperature>(), Arg.Any<Localization>()).Returns(default(PackingList));
            
            //ACT
            var exception = await Record.ExceptionAsync(() => Act(command));

            //ASSERT
            exception.ShouldBeNull();
            await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
        }

        #region ARRANGE

        private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;

        public CreatePackingListWithItemsHandlerTests()
        {
            _repository = Substitute.For<IPackingListRepository>();
            _weatherService = Substitute.For<IWeatherService>();
            _readService = Substitute.For<IPackingListReadService>();
            _factory = Substitute.For<IPackingListFactory>();

            _commandHandler = new CreatePackingListWithItemsHandler(_repository, _readService, _factory, _weatherService);
        }

        #endregion 
    }
}
