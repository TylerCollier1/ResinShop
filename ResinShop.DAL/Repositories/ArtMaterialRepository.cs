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
    public class ArtMaterialRepository : IArtMaterialRepository
    {
        private DbContextOptions _dbContextOptions;

        public Response Delete(int artMaterialId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    db.ArtMaterial.Remove(db.ArtMaterial.Find(artMaterialId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "ArtMaterial deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<ArtMaterial> Get(int artMaterialId)
        {
            Response<ArtMaterial> response = new Response<ArtMaterial>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                var artMaterial = db.ArtMaterial.Find(artMaterialId);
                if (artMaterial != null)
                {
                    response.Data = artMaterial;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.AddMessage("ArtMaterial not found.");
                }
            }
            return response;
        }

        public Response<List<ArtMaterial>> GetAll()
        {
            Response<List<ArtMaterial>> response = new Response<List<ArtMaterial>>();

            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    var artMaterial = db.ArtMaterial.ToList();
                    response.Data = artMaterial;
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

        public Response<ArtMaterial> Insert(ArtMaterial artMaterial)
        {
            Response<ArtMaterial> response = new Response<ArtMaterial>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.ArtMaterial.Add(artMaterial);
                db.SaveChanges();

                response.Data = artMaterial;
                response.Success = true;
                response.Message = "ArtMaterial added.";
            }
            return response;
        }

        public Response Update(ArtMaterial artMaterial)
        {
            Response response = new Response();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.ArtMaterial.Update(artMaterial);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated artMaterial";
            }
            return response;
        }
    }
}
