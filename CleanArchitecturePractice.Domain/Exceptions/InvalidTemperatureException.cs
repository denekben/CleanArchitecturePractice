using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Domain.Exceptions
{
    public class InvalidTemperatureException : PackItException
    {
        public double Temperature { get; }
        public InvalidTemperatureException(double temperature) : base($"Temperature {temperature} is invalid.")
        {
            Temperature = temperature;
        }
    }
}
