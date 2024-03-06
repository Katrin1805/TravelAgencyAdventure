using Microsoft.AspNetCore.Identity;
using System.Runtime.ExceptionServices;

namespace TuristicheskaAganciq.Data
{
    public class Client:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public ICollection<Rezervation> Rezervations { get; set; }

    }
}
