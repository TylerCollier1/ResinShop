using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.DTO
{
    public class OrdersOver5000
    {
        public int OrderId { get; set; }
        public int ArtId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Cost { get; set; }
    }
}
