using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.DTO
{
    public class CustomerQuotes
    {
        public int ArtId { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int MaterialQuantity { get; set; }
        public int ColorQuantity { get; set; }
        public decimal Cost { get; set; }
    }
}
