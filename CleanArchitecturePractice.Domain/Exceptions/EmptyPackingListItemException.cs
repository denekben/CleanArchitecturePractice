using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Domain.Exceptions
{
    public class EmptyPackingListItemException : PackItException
    {
        public EmptyPackingListItemException() : base("Packing item name cannot be empty.")
        {
        }
    }
}
