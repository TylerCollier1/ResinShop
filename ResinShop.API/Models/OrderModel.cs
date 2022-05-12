using ResinShop.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ResinShop.API.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Art Art { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
