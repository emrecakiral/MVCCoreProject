using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.ViewModels
{
    public class PaymentVM
    {

        [Required(ErrorMessage ="Zorunlu Alan")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string CartNumber { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Cvv { get; set; }
    }
}
