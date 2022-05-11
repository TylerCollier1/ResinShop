using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core.Entities
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public List<ArtColor> ArtColor { get; set; }
    }
}
