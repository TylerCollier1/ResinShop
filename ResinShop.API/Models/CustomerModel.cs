using System.ComponentModel.DataAnnotations;

namespace ResinShop.API.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(25, ErrorMessage = "First name cannot be longer than 25 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(25, ErrorMessage = "Last name cannot be longer than 25 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [StringLength(50, ErrorMessage = "Email Address cannot be longer than 25 characters.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Street address is required.")]
        [StringLength(50, ErrorMessage = "Street Address cannot be longer than 25 characters.")]
        public string StreetAddress { get; set; }
        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 25 characters.")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required.")]
        [StringLength(25, ErrorMessage = "State cannot be longer than 25 characters.")]
        public string StateName { get; set; }
        [Required(ErrorMessage = "Zip code is required.")]
        [StringLength(15, ErrorMessage = "Zip Code cannot be longer than 15 characters.")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(25, ErrorMessage = "Phone Number cannot be longer than 25 characters.")]
        public string PhoneNumber { get; set; }
    }
}
