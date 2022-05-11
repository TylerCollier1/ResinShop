using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core.DTO;
using ResinShop.Core.Entities;

namespace ResinShop.Core.Interfaces.DAL
{
    public interface IReportsRepository
    {
        Response<List<OrdersOver5000>> GetOrdersOver5000();
        Response<List<LargeArtPieces>> GetLargeArtPieces();
        Response<List<HasAdvancedFeatures>> GetAdvancedFeatures();
    }
}
