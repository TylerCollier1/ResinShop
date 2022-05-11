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
            private readonly IConfigurationRoot Config;
            string connectionString;
            private readonly FactoryMode mode;

            public ReportsRepository(IConfigurationRoot config)
            {
                Config = config;
                string environment = mode == FactoryMode.TEST ? "Test" : "Prod";
                connectionString = Config[$"ConnectionStrings:{environment}"];
            }

        public Response<List<OrdersOver5000>> GetOrdersOver5000()
        {
            Response<List<OrdersOver5000>> response = new Response<List<OrdersOver5000>>();
            response.Data = new List<OrdersOver5000>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
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
                using (var connection = new SqlConnection(connectionString))
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
                using (var connection = new SqlConnection(connectionString))
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
    }
}
