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
        Response<List<CustomerInfo>> GetCustomerInfo(int customerId);
        Response<List<CustomerOrders>> GetCustomerOrders(int customerId);
        Response<List<CustomerQuotes>> GetCustomerQuotes(int customerId);
        Response<List<OrderDisplayInfo>> GetOrderDisplay();
        Response<List<OrderDetails>> GetOneOrderDetails(int customerId);
    }
}
