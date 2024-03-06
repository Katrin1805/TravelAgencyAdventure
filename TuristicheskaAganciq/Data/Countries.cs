namespace TuristicheskaAganciq.Data
{
    public class Countries
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public  ICollection<Destinations>Destination{ get; set; }

    }
}
