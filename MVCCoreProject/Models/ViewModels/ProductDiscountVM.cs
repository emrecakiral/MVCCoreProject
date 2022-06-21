namespace MVCCoreProject.Models.ViewModels
{
    public class ProductDiscountVM
    {
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }

        public decimal Discount { get; set; }

        // Encapsulation
        public decimal? NewPrice
        {
            get
            {
                decimal? p = (OldPrice / 100) * Discount;
                return OldPrice - p;
            }
        }

        public decimal? OldPrice { get; set; }
    }
}
