using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core.Entities;

namespace ResinShop.Core.Interfaces.DAL
{
    public interface IMaterialRepository
    {
        Response<Material> Insert(Material material);
        Response Update(Material material);
        Response Delete(int materialId);
        Response<Material> Get(int materialId);
    }
}
