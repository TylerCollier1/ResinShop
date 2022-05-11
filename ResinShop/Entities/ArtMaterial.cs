using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.Entities
{
    public class ArtMaterial
    {
        public int ArtId { get; set; }
        public Art Art { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
