using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.ViewModels
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name="Kategori Adı")]
        [Required(ErrorMessage ="Kategori alanı zorunludur")]
        [StringLength(15,ErrorMessage ="Maximimum 15 karakter girilebilir")]
        public string Name { get; set; }


        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        public string Description { get; set; }
    }
}