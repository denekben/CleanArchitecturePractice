using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Domain.Exceptions
{
    public class EmptyPackingListIdException : PackItException
    {
        public EmptyPackingListIdException() : base("Packing list id cannot be empty.")
        {
        }
    }
}
