using CleanArchitecturePractice.Domain.ValueObjects;

namespace CleanArchitecturePractice.Domain.Policies
{
    public record PolicyData(TravelDays TravelDays, Consts.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization);
}
