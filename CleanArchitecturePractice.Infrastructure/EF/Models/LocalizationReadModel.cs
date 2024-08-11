namespace CleanArchitecturePractice.Infrastructure.EF.Models
{
    internal class LocalizationReadModel
    {
        public string City { get; set; }
        public string Country { get; set; }

        public static LocalizationReadModel Create(string value)
        {
            var splitedLocalization = value.Split(',');
            return new LocalizationReadModel { City = splitedLocalization.First(), Country = splitedLocalization.Last() };
        }

        public override string ToString()
        {
            return $"{City},{Country}";
        }
    }
}
