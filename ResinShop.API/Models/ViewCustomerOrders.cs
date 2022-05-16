namespace ResinShop.API.Models
{
    public class ViewCustomerOrders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Cost { get; set; }
        public int ArtId { get; set; }
    }
}
