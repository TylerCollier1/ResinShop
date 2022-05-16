using ResinShop.Core;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DbContextOptions _dbContextOptions;

        public OrderRepository(FactoryMode mode = FactoryMode.TEST)
        {
            _dbContextOptions = DBFactory.GetDbContext(mode);
        }

        public Response Delete(int orderId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
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
            using (var db = new AppDbContext(_dbContextOptions))
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
                using (var db = new AppDbContext(_dbContextOptions))
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
            using (var db = new AppDbContext(_dbContextOptions))
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
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.Order.Update(order);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated order";
            }
            return response;
        }
        public void SetKnownGoodState()
        {
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.Database.ExecuteSqlRaw("SetKnownGoodState");
            }
        }
    }
}
