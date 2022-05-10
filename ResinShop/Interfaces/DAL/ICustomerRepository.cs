using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResinShop.Core.Entities;

namespace ResinShop.Core.Interfaces.DAL
{
    public interface ICustomerRepository
    {
        Response<Customer> Insert(Customer customer);
        Response Update(Customer customer);
        Response Delete(int customerId);
        Response<Customer> Get(int customerId);
    }
}
