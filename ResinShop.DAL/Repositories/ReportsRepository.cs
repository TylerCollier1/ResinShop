using Microsoft.Extensions.Configuration;
using ResinShop.Core;
using ResinShop.Core.DTO;
using ResinShop.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        public string ConnectionString { get; set; }
        public ReportsRepository(DBFactory dBFactory)
        {
            ConnectionString = dBFactory.GetConnection();
        }

        public Response<List<OrdersOver5000>> GetOrdersOver5000()
        {
            Response<List<OrdersOver5000>> response = new Response<List<OrdersOver5000>>();
            response.Data = new List<OrdersOver5000>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var cmd = new SqlCommand("OrdersOver5000", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Data.Add(new OrdersOver5000
                            {
                                OrderId = (int)reader["OrderId"],
                                ArtId = (int)reader["ArtId"],
                                FirstName = reader["First Name"].ToString(),
                                LastName = reader["Last Name"].ToString(),
                                Cost = (decimal)reader["Cost"],
                            });
                            response.Success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<LargeArtPieces>> GetLargeArtPieces()
        {
            Response<List<LargeArtPieces>> response = new Response<List<LargeArtPieces>>();
            response.Data = new List<LargeArtPieces>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var cmd = new SqlCommand("LargeArtPieces", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Data.Add(new LargeArtPieces
                            {
                                ArtId = (int)reader["ArtId"],
                                FirstName = reader["First Name"].ToString(),
                                LastName = reader["Last Name"].ToString(),
                                Height = (decimal)reader["Height"],
                                Width = (decimal)reader["Width"],
                            });
                            response.Success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<HasAdvancedFeatures>> GetAdvancedFeatures()
        {
            Response<List<HasAdvancedFeatures>> response = new Response<List<HasAdvancedFeatures>>();
            response.Data = new List<HasAdvancedFeatures>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var cmd = new SqlCommand("HasAdvancedFeatures", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.Data.Add(new HasAdvancedFeatures
                            {
                                ArtId = (int)reader["ArtId"],
                                FirstName = reader["First Name"].ToString(),
                                LastName = reader["Last Name"].ToString(),
                                AdvancedFeatureName = reader["Advanced Feature Name"].ToString(),
                            });
                            response.Success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<CustomerInfo>> GetCustomerInfo(int customerId)
        {
            var response = new Response<List<CustomerInfo>>();
            response.Data = new List<CustomerInfo>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("CustomerInfo", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                try
                {
                    connection.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            response.Data.Add(new CustomerInfo
                            {
                                CustomerId = (int)dr["CustomerId"],
                                ArtId = (int)dr["ArtId"],
                                AdvancedFeatureId = (int)dr["AdvancedFeatureId"],
                                OrderId = (int)dr["OrderId"],
                                FirstName = dr["FirstName"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Email = dr["Email"].ToString(),
                                StreetAddress = dr["StreetAddress"].ToString(),
                                City = dr["City"].ToString(),
                                StateName = dr["StateName"].ToString(),
                                ZipCode = dr["ZipCode"].ToString(),
                                PhoneNumber = dr["PhoneNumber"].ToString(),
                                Height = (decimal)dr["Height"],
                                Width = (decimal)dr["Width"],
                                MaterialQuantity = (int)dr["MaterialQuantity"],
                                ColorQuantity = (int)dr["ColorQuantity"],
                                Cost = (decimal)dr["Cost"],
                            });
                            response.Success = true;
                        }
                    }
                }
                catch (Exception)
                {
                    response.Success = false;
                    response.Message = "Customer Information not found.";
                }
            }
            return response;
        }

        public Response<List<CustomerOrders>> GetCustomerOrders(int customerId)
        {
            var response = new Response<List<CustomerOrders>>();
            response.Data = new List<CustomerOrders>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("CustomerOrders", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                try
                {
                    connection.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            response.Data.Add(new CustomerOrders
                            {
                                OrderId = (int)dr["OrderId"],
                                OrderDate = (DateTime)dr["OrderDate"],
                                Height = (decimal)dr["Height"],
                                Width = (decimal)dr["Width"],
                                Cost = (decimal)dr["Cost"],
                                ArtId = (int)dr["ArtId"],
                            });
                            response.Success = true;
                        }
                    }
                }
                catch (Exception)
                {
                    response.Success = false;
                    response.Message = "No orders found.";
                }
            }
            return response;
        }

        public Response<List<CustomerQuotes>> GetCustomerQuotes(int customerId)
        {
            var response = new Response<List<CustomerQuotes>>();
            response.Data = new List<CustomerQuotes>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("CustomerQuotes", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                try
                {
                    connection.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            response.Data.Add(new CustomerQuotes
                            {
                                ArtId = (int)dr["ArtId"],
                                Height = (decimal)dr["Height"],
                                Width = (decimal)dr["Width"],
                                MaterialQuantity = (int)dr["MaterialQuantity"],
                                ColorQuantity = (int)dr["ColorQuantity"],
                                Cost = (decimal)dr["Cost"],
                            });
                            response.Success = true;
                        }
                    }
                }
                catch (Exception)
                {
                    response.Success = false;
                    response.Message = "No quotes found.";
                }
            }
            return response;
        }
    }
}