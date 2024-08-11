using CleanArchitecturePractice.Application.DTO.External;
using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(Localization localization);
    }
}
