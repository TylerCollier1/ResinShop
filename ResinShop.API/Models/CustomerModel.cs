using System.ComponentModel.DataAnnotations;

namespace ResinShop.API.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Street address is required.")]
        public string StreetAddress { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required.")]
        public string StateName { get; set; }
        [Required(ErrorMessage = "Zip code is required.")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }
    }
}
