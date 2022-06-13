using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Areas.Manage.Models.ViewModels
{
    public class RegionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        [StringLength(50, ErrorMessage = "Maximimum 50 karakter girilebilir")]
        public string Description { get; set; }
    }
}
