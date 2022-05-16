using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.DTO
{
    public class CustomerInfo
    {
        public int CustomerId { get; set; }
        public int ArtId { get; set; }
        public int AdvancedFeatureId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int MaterialQuantity { get; set; }
        public int ColorQuantity { get; set; }
        public decimal Cost { get; set; }
    }
}
