using CleanArchitecturePractice.Domain.Exceptions;

namespace CleanArchitecturePractice.Domain.ValueObjects
{
    public record PackingListName
    {
        public string Value { get; }

        public PackingListName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyPackingListNameException();
            }
            Value = value;
        }

        public static implicit operator string(PackingListName packingListName)
            => packingListName.Value;

        public static implicit operator PackingListName(string packingListName)
            => new(packingListName);
        
    }
}
