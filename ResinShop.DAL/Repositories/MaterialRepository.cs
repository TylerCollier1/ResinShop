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
    public class MaterialRepository : IMaterialRepository
    {
        private DbContextOptions _dbContextOptions;

        public Response Delete(int materialId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    db.Material.Remove(db.Material.Find(materialId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Material deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Material> Get(int materialId)
        {
            Response<Material> response = new Response<Material>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                var material = db.Material.Find(materialId);
                if (material != null)
                {
                    response.Data = material;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.AddMessage("Material not found.");
                }
            }
            return response;
        }

        public Response<List<Material>> GetAll()
        {
            Response<List<Material>> response = new Response<List<Material>>();

            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    var material = db.Material.ToList();
                    response.Data = material;
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

        public Response<Material> Insert(Material material)
        {
            Response<Material> response = new Response<Material>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.Material.Add(material);
                db.SaveChanges();

                response.Data = material;
                response.Success = true;
                response.Message = "Material added.";
            }
            return response;
        }

        public Response Update(Material material)
        {
            Response response = new Response();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.Material.Update(material);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated material";
            }
            return response;
        }
    }
}
