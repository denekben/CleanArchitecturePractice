using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Application.Exceptions
{
    public class MissingLocalizationWeatherException : PackItException
    {
        public Localization Localization { get; }
        public MissingLocalizationWeatherException(Localization localization) 
            : base($"Couldn't fetch data for localization '{localization.ToString()}'")
        {
            Localization = localization;
        }
    }
}
