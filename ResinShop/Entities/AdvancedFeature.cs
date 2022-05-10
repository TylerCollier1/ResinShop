using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.Entities
{
    public class AdvancedFeature
    {
        public int AdvancedFeatureId { get; set; }
        public string AdvancedFeatureName { get; set; }
        public List<Art> Art { get; set; }
    }
}
