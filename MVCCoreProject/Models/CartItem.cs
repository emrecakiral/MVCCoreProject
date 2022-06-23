namespace MVCCoreProject.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Adet { get; set; }
        public decimal? BirimFiyat { get; set; }

        public string ProductName { get; set; }

        public decimal Fiyat { get; set; }
    }
}