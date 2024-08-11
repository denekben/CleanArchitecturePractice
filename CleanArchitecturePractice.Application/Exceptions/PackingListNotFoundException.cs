using CleanArchitecturePractice.Shared.Abstractions.Exceptions;

namespace CleanArchitecturePractice.Application.Exceptions
{
    public class PackingListNotFoundException : PackItException
    {
        public Guid Id { get; }
        public PackingListNotFoundException(Guid id) : base($"Packing list with id = {id} not found.")
        {
            Id = id;
        }
    }
}
