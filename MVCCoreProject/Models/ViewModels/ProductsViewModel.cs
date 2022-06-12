using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.ViewModels
{
    public class ProductsViewModel
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ProductID { get; set; }


        [Display(Name="Ürün Adı")]
        [Required(ErrorMessage ="Ürün Adı alanı zorunludur")]
        [StringLength(40,ErrorMessage ="En fazla 40 karakter girilebilir")]
        public string ProductName { get; set; }


        [Display(Name ="Tedarikçi ID")]
        public int SupplierID { get; set; }


        [Display(Name ="Kategori ID")]
        public int CategoryID { get; set; }

        [Display(Name ="Birim Miktarı")]
        [StringLength(20,ErrorMessage ="En fazla 20 karakter girilebilir")]
        public string QuantityPerUnit { get; set; }

        
        [Display(Name ="Birim Fiyatı")]
        public decimal UnitPrice { get; set; }


        [Display(Name ="Stok")]
        public Int16 UnitsInStock { get; set; }

        [Display(Name ="Sipariş")]
        public Int16 UnitsOnOrder { get; set; }


        [Display(Name ="Sipariş Sıklığı")]
        public Int16 ReorderLevel { get; set; }


        [Display(Name ="Satışa Kapalı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public bool Discontinued { get; set; }
    }
}
