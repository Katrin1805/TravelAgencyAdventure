using System.ComponentModel.DataAnnotations.Schema;

namespace TuristicheskaAganciq.Data
{
    public class Excursion
    {
        public int Id { get; set; }
        public string DestinationsId { get; set; }
        public Destinations Destination { get; set; }
        public string VidTransport {  get; set; }
        public string Period {  get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price {  get; set; }
        public string Description {  get; set; }
        public string DateRegister {  get; set; }

        public ICollection<Rezervation>Rezervations { get; set; }
    }
}
