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
    public class ColorRepository : IColorRepository
    {
        private DbContextOptions _dbContextOptions;

        public Response Delete(int orderId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    db.Color.Remove(db.Color.Find(orderId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Color deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Color> Get(int orderId)
        {
            Response<Color> response = new Response<Color>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                var order = db.Color.Find(orderId);
                if (order != null)
                {
                    response.Data = order;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.AddMessage("Color not found.");
                }
            }
            return response;
        }

        public Response<List<Color>> GetAll()
        {
            Response<List<Color>> response = new Response<List<Color>>();

            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    var order = db.Color.ToList();
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

        public Response<Color> Insert(Color order)
        {
            Response<Color> response = new Response<Color>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.Color.Add(order);
                db.SaveChanges();

                response.Data = order;
                response.Success = true;
                response.Message = "Color added.";
            }
            return response;
        }

        public Response Update(Color order)
        {
            Response response = new Response();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.Color.Update(order);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated order";
            }
            return response;
        }
    }
}
