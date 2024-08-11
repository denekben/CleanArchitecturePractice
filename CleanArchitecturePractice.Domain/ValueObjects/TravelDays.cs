using CleanArchitecturePractice.Domain.Exceptions;

namespace CleanArchitecturePractice.Domain.ValueObjects
{
    public class TravelDays
    {
        public ushort Value { get; }

        public TravelDays(ushort value)
        {
            if (value <= 0 || value > 100)
            {
                throw new InvalidTravelDaysException();
            }
            Value = value;
        }

        public static implicit operator ushort(TravelDays travelDays)
            => travelDays.Value;

        public static implicit operator TravelDays(ushort travelDays)
            => new(travelDays);
    }
}
