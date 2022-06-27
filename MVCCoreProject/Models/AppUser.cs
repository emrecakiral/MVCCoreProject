using Microsoft.AspNetCore.Identity;

namespace MVCCoreProject.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
    }
}
