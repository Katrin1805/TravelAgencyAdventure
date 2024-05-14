 namespace TuristicheskaAganciq.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
        public  ICollection<Destination>Destinations{ get; set; }

    }
}
