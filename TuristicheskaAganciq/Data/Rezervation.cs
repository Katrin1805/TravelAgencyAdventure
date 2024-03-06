namespace TuristicheskaAganciq.Data
{
    public class Rezervation
    {
        public int Id { get; set; }
        public string ClientsId { get; set; }
        public Client Clients { get; set; }
        public int ExcursionsId { get; set; }
        public Excursion Excursions { get; set; }
        public int Pasangers { get; set; }
        public DateTime Begin { get; } = DateTime.Now;
        public DateTime RegisterDate { get; set; }
    }

}
    


    

