using ResinShop.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ResinShop.API.Models
{
    public class ViewOrderModel
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "CustomerId is required")]
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "ArtId is required")]
        public Art Art { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
