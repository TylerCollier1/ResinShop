using ResinShop.Core;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public DBFactory DbFac { get; set; }

        public CustomerRepository(DBFactory dBFactory)
        {
            DbFac = dBFactory;
        }

        public Response Delete(int customerId) //TODO: Fix this one after ORDER Repo is complete
        {
            Response response = new Response();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    db.Customer.Remove(db.Customer.Find(customerId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Customer deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> Get(int customerId)
        {
            Response<Customer> response = new Response<Customer>();
            using (var db = DbFac.GetDbContext())
            {
                try
                {
                    var customer = db.Customer.Find(customerId);
                    if (customer != null)
                    {
                        response.Data = customer;
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.AddMessage("Customer not found.");
                    }
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.AddMessage(ex.Message);
                }
                return response;
            }
        }

        public Response<List<Customer>> GetAll()
        {
            Response<List<Customer>> response = new Response<List<Customer>>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    var customer = db.Customer.ToList();
                    response.Data = customer;
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

        public Response<Customer> Insert(Customer customer)
        {
            Response<Customer> response = new Response<Customer>();

            using (var db = DbFac.GetDbContext())
            {
                try
                {
                    db.Customer.Add(customer);
                    db.SaveChanges();

                    response.Data = customer;
                    response.Success = true;
                    response.Message = "Customer added.";
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.AddMessage(ex.Message);
                }

                return response;
            }
        }

        public Response Update(Customer customer)
        {
            Response response = new Response();

            using (var db = DbFac.GetDbContext())
                try
                {
                    db.Customer.Update(customer);
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Customer updated";
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.AddMessage(ex.Message);
                }
            return response;
        }
    }
}

