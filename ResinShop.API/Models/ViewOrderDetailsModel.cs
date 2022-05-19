namespace ResinShop.API.Models
{
    public class ViewOrderDetailsModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Cost { get; set; }
    }
}
