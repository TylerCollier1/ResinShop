using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ResinShop.DAL.Repositories
{
    public class ArtRepository : IArtRepository
    {
        private DbContextOptions dbContextOptions;

        public ArtRepository(FactoryMode mode = FactoryMode.TEST)
        {
            dbContextOptions = DBFactory.GetDbContext(mode);
        }

        public Response Delete(int artId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(dbContextOptions))
                {
                    db.Arts.Remove(db.Arts.Find(artId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Art deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Art> Get(int artId)
        {
            Response<Art> response = new Response<Art>();
            using (var db = new AppDbContext(dbContextOptions))
            {
                var art = db.Arts.Find(artId);
                if (art != null)
                {
                    response.Data = art;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.AddMessage("Art not found.");
                }
            }
            return response;
        }

        public Response<Art> Insert(Art art)
        {
            Response<Art> response = new Response<Art>();
            using (var db = new AppDbContext(dbContextOptions))
            {
                db.Arts.Add(art);
                db.SaveChanges();

                response.Data = art;
                response.Success = true;
                response.Message = "Art added.";
            }
            return response;
        }

        public Response Update(Art art)
        {
            Response response = new Response();
            using (var db = new AppDbContext(dbContextOptions))
            {
                db.Arts.Update(art);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated art";
            }
            return response;
        }
    }
}
