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
        public DBFactory DbFac { get; set; }

        public ArtRepository(DBFactory dBFactory)
        {
            DbFac = dBFactory;
        }

        public Response Delete(int artId) //TODO: Fix this one after ORDER Repo is complete
        {
            Response response = new Response();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    db.Art.Remove(db.Art.Find(artId));
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
            using (var db = DbFac.GetDbContext())
            {
                var art = db.Art.Find(artId);
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

        public Response<List<Art>> GetAll()
        {
            Response<List<Art>> response = new Response<List<Art>>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    var art = db.Art.ToList();
                    response.Data = art;
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

        public Response<Art> Insert(Art art)
        {
            Response<Art> response = new Response<Art>();
            using (var db = DbFac.GetDbContext())
            {
                db.Art.Add(art);
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
            using (var db = DbFac.GetDbContext())
            {
                db.Art.Update(art);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated art";
            }
            return response;
        }
    }
}