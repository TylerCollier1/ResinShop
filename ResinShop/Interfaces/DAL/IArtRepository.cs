using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core.Entities;

namespace ResinShop.Core.Interfaces.DAL
{
    public interface IArtRepository
    {
        Response<Art> Insert(Art art);
        Response Update(Art art);
        Response Delete(int artId);
        Response<Art> Get(int artId);
        Response<List<Art>> GetAll();
    }
}
