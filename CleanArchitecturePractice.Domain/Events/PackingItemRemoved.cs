using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Shared.Abstractions.Domain;

namespace CleanArchitecturePractice.Domain.Events
{
    public record PackingItemRemoved(PackingList PackingList, PackingItem PackingItem):IDomainEvent
    {
    }
}
