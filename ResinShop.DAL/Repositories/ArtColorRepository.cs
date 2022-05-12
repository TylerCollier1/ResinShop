using ResinShop.Core;
using ResinShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Repositories
{
    public class ArtColorRepository
    {
        public DBFactory DbFac { get; set; }

        public ArtColorRepository(DBFactory dBFactory)
        {
            DbFac = dBFactory;
        }

        public Response Delete(int artColorId)
        {
            Response response = new Response();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    db.ArtColor.Remove(db.ArtColor.Find(artColorId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "ArtColor deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<ArtColor> Get(int artColorId)
        {
            Response<ArtColor> response = new Response<ArtColor>();
            using (var db = DbFac.GetDbContext())
            {
                var artColor = db.ArtColor.Find(artColorId);
                if (artColor != null)
                {
                    response.Data = artColor;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.AddMessage("ArtColor not found.");
                }
            }
            return response;
        }

        public Response<List<ArtColor>> GetAll()
        {
            Response<List<ArtColor>> response = new Response<List<ArtColor>>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    var artColor = db.ArtColor.ToList();
                    response.Data = artColor;
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

        public Response<ArtColor> Insert(ArtColor artColor)
        {
            Response<ArtColor> response = new Response<ArtColor>();
            using (var db = DbFac.GetDbContext())
            {
                db.ArtColor.Add(artColor);
                db.SaveChanges();

                response.Data = artColor;
                response.Success = true;
                response.Message = "ArtColor added.";
            }
            return response;
        }

        public Response Update(ArtColor artColor)
        {
            Response response = new Response();
            using (var db = DbFac.GetDbContext())
            {
                db.ArtColor.Update(artColor);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Updated artColor";
            }
            return response;
        }
    }
}
