using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Domain.Exceptions
{
    internal class InvalidTravelDaysException : PackItException
    {
        public InvalidTravelDaysException() : base("TravelDays must be positive and less than 100")
        {
        }
    }
}
