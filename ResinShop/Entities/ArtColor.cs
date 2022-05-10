using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.Entities
{
    public class ArtColor
    {
        public int ArtId { get; set; }
        public Art Art { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
