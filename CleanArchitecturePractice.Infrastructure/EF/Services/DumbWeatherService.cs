using CleanArchitecturePractice.Application.DTO.External;
using CleanArchitecturePractice.Application.Services;
using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Infrastructure.EF.Services
{
    internal sealed class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Localization localization)
        {
            return Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
        }
    }
}
