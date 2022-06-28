using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.ViewModels
{
    public class UserAdressVM
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name ="Başlık")]
        [Required]
        public string Baslik { get; set; }

        [Display(Name = "Açık Adres")]
        [Required]
        public string AcikAdres { get; set; }

        [Display(Name = "İl")]
        [Required]
        public string Il { get; set; }

        [Display(Name = "İlçe")]
        [Required]
        public string Ilce { get; set; }


        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        public bool Active { get; set; }
    }
}
