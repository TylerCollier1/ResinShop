using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.Entities
{
    public class Art
    {
        public int ArtId { get; set; }
        public int AdvancedFeatureId { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int MaterialQuantity { get; set; }
        public int ColorQuantity { get; set; }
        public decimal Cost { get; set; }
        public AdvancedFeature? AdvancedFeature { get; set; }
        public List<ArtMaterial>? ArtMaterial { get; set; }
        public List<ArtColor>? ArtColor { get; set; }
    }
}
