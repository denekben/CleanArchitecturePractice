using CleanArchitecturePractice.Domain.Exceptions;

namespace CleanArchitecturePractice.Domain.ValueObjects
{
    public record Temperature
    {
        public double Value { get; }

        public Temperature(double value)
        {
            if (value < -100 || value > 100)
            {
                throw new InvalidTemperatureException(value);
            }
            Value = value;
        }

        public static implicit operator double(Temperature temp)
            => temp.Value;

        public static implicit operator Temperature(double temp)
            => new(temp);
    }
}
