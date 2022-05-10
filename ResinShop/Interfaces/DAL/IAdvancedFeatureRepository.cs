using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core.Entities;

namespace ResinShop.Core.Interfaces.DAL
{
    public interface IAdvancedFeatureRepository
    {
        Response<AdvancedFeature> Get(int advancedFeatureId);
        Response<List<AdvancedFeature>> GetAll();
    }
}
