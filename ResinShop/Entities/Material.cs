using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.Entities
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public List<ArtMaterial> ArtMaterial { get; set; }
    }
}
