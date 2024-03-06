namespace TuristicheskaAganciq.Data
{
    public class Destinations
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CountriesId { get; set; } //FK
        public Countries Country{ get; set; } //M:1
    }
}
