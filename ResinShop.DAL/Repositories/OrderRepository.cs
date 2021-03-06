using ResinShop.Core;
using ResinShop.Core.DTO;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public DBFactory DbFac { get; set; }
        public string ConnectionString { get; set; }

        public OrderRepository(DBFactory dBFactory)
        {
            DbFac = dBFactory;
        }

        public Response Delete(int orderId)
        {
            Response response = new Response();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    db.Order.Remove(db.Order.Find(orderId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Order deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Order> Get(int orderId)
        {
            Response<Order> response = new Response<Order>();
            using (var db = DbFac.GetDbContext())
            {
                var order = db.Order.Find(orderId);
                if (order != null)
                {
                    response.Data = order;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.AddMessage("Order not found.");
                }
            }
            return response;
        }

        public Response<List<Order>> GetAll()
        {
            Response<List<Order>> response = new Response<List<Order>>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    var order = db.Order.ToList();
                    response.Data = order;
                    response.Success = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public Response<Order> Insert(Order order)
        {
            Response<Order> response = new Response<Order>();
            using (var db = DbFac.GetDbContext())
            {
                db.Order.Add(order);
                db.SaveChanges();

                response.Data = order;
                response.Success = true;
                response.Message = "Order added.";
            }
            return response;
        }

        public Response Update(Order order)
        {
            Response response = new Response();
            using (var db = DbFac.GetDbContext())
            {
                db.Order.Update(order);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated order";
            }
            return response;
        }
    }
}