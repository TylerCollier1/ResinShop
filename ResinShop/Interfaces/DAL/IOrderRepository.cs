using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core.Entities;

namespace ResinShop.Core.Interfaces.DAL
{
    public interface IOrderRepository
    {
        Response<Order> Insert(Order order);
        Response Update(Order order);
        Response Delete(int orderId);
        Response<Order> Get(int orderId);
        Response<List<Order>> GetAll();
    }
}
