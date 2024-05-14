namespace TuristicheskaAganciq.Data
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountriesId { get; set; } //FK
        public Country Countries{ get; set; } //M:1
        public ICollection<Excursion> Excursions { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
