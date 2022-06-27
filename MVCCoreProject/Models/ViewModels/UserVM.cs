using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.ViewModels
{
    public class UserVM
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string City { get; set; }
        public string Town { get; set; }

        [Required]
        public string UserName { get; set; }
     
        [Required]
        public string Email { get; set; }
    
        [Required]
        public string Password { get; set; }
    }
}
