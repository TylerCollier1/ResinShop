using ResinShop.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ResinShop.API.Models
{
    public class ArtModel
    {
        public int ArtId { get; set; }
        public int AdvancedFeatureId { get; set; }
        [Required(ErrorMessage = "Height is required")]
        public decimal Height { get; set; }
        [Required(ErrorMessage = "Width is required")]
        public decimal Width { get; set; }
        public int MaterialQuantity { get; set; }
        public int ColorQuantity { get; set; }
        public decimal Cost { get; set; } //need to change in core to decimal (and maybe database)
    }
}
