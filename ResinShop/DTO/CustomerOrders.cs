using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.DTO
{
    public class CustomerOrders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Cost { get; set; }
        public int ArtId { get; set; }
    }
}
