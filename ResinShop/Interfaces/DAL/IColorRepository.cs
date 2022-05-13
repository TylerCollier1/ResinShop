using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core.Entities;

namespace ResinShop.Core.Interfaces.DAL
{
    public interface IColorRepository
    {
        Response<Color> Insert(Color color);
        Response Update(Color color);
        Response Delete(int colorId);
        Response<Color> Get(int colorId);
        Response<List<Color>> GetAll();

    }
}
