using ResinShop.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ResinShop.API.Models
{
    public class ViewCustomerModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
