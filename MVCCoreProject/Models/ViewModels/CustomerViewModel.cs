using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.ViewModels
{

        public class CustomerViewModel
        {
            [ScaffoldColumn(false)]
            [Key]
             public string ID { get; set; }

            [Display(Name = "Müşteri Adı")]
            [Required(ErrorMessage = "Müşteri adı zorunludur")]
            //[StringLength(15, ErrorMessage = "Maximimum 30 karakter girilebilir")]
            public string ContactName { get; set; }


            [Display(Name = "Şirket Adı")]
            [Required(ErrorMessage = "Şirket Adı alanı zorunludur")]
            public string CompanyName { get; set; }
        }
    
}
