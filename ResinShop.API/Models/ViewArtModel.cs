using ResinShop.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ResinShop.API.Models
{
    public class ViewArtModel
    {
        public int ArtId { get; set; }
        public int AdvancedFeatureId { get; set; }
        [Required(ErrorMessage = "Height is required")]
        public decimal Height { get; set; }
        [Required(ErrorMessage = "Width is required")]
        public decimal Width { get; set; }
        [Required(ErrorMessage = "MaterialQuantity is required")]
        public int MaterialQuantity { get; set; }
        [Required(ErrorMessage = "ColorQuantity is required")]
        public int ColorQuantity { get; set; }
        public decimal Cost { get; set; }
    }
}
