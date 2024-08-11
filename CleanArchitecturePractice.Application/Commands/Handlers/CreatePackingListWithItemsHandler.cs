using CleanArchitecturePractice.Application.Exceptions;
using CleanArchitecturePractice.Application.Services;
using CleanArchitecturePractice.Domain.Factories;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Shared.Abstractions.Commands;

namespace CleanArchitecturePractice.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _packingListRepository;
        private readonly IPackingListReadService _packingListReadService;
        private readonly IPackingListFactory _packingListFactory;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListRepository packingListRepository,
            IPackingListReadService packingListReadService, IPackingListFactory packingListFactory,
            IWeatherService weatherService)
        {
            _packingListRepository = packingListRepository;
            _packingListReadService = packingListReadService;
            _packingListFactory = packingListFactory;
            _weatherService = weatherService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (name, days, gender, localizationWriteModel) = command;

            if (await _packingListReadService.ExistsByNameAsync(name))
            {
                throw new PackingListAlreadyExistsException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if(weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            }

            var packingList = _packingListFactory.CreateWithDefaultItems(name, days, gender, weather.Temperature, localization);
        
            await _packingListRepository.AddAsync(packingList);
        }
    }
}
