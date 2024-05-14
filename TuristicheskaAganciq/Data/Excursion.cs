using System.ComponentModel.DataAnnotations.Schema;

namespace TuristicheskaAganciq.Data
{
    public class Excursion
    {
        public int Id { get; set; }
        public string ExcursionNumber { get; set; }
        public int DestinationsId { get; set; }
        public Destination Destinations { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string VidTransport {  get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price {  get; set; }
        public DateTime DateRegister { get; set; } = DateTime.Now;

        public ICollection<Rezervation>Rezervations { get; set; }
    }
}
