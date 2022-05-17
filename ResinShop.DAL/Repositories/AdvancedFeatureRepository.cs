using ResinShop.Core;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Repositories
{
    public class AdvancedFeatureRepository : IAdvancedFeatureRepository
    {
        private DbContextOptions _dbContextOptions;

        public Response Delete(int advancedFeatureId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    db.AdvancedFeature.Remove(db.AdvancedFeature.Find(advancedFeatureId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "AdvancedFeature deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<AdvancedFeature> Get(int advancedFeatureId)
        {
            Response<AdvancedFeature> response = new Response<AdvancedFeature>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                var advancedFeature = db.AdvancedFeature.Find(advancedFeatureId);
                if (advancedFeature != null)
                {
                    response.Data = advancedFeature;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.AddMessage("AdvancedFeature not found.");
                }
            }
            return response;
        }

        public Response<List<AdvancedFeature>> GetAll()
        {
            Response<List<AdvancedFeature>> response = new Response<List<AdvancedFeature>>();

            try
            {
                using (var db = new AppDbContext(_dbContextOptions))
                {
                    var advancedFeature = db.AdvancedFeature.ToList();
                    response.Data = advancedFeature;
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

        public Response<AdvancedFeature> Insert(AdvancedFeature advancedFeature)
        {
            Response<AdvancedFeature> response = new Response<AdvancedFeature>();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.AdvancedFeature.Add(advancedFeature);
                db.SaveChanges();

                response.Data = advancedFeature;
                response.Success = true;
                response.Message = "AdvancedFeature added.";
            }
            return response;
        }

        public Response Update(AdvancedFeature advancedFeature)
        {
            Response response = new Response();
            using (var db = new AppDbContext(_dbContextOptions))
            {
                db.AdvancedFeature.Update(advancedFeature);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated advancedFeature";
            }
            return response;
        }
    }
}
