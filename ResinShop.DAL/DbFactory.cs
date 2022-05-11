using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ResinShop.DAL
{
    public enum FactoryMode
    {
        TEST,
        PROD
    }

    public class DBFactory
    {
        private readonly IConfigurationRoot Config;
        private readonly FactoryMode Mode;

        public DBFactory(IConfigurationRoot config, FactoryMode mode = FactoryMode.PROD)
        {
            Config = config;
            Mode = mode;
        }

        public AppDbContext GetDbContext()
        {
            string environment = Mode == FactoryMode.TEST ? "Test" : "Prod";

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(Config[$"ConnectionStrings:{environment}"])
                .Options;
            return new AppDbContext(options);
        }

        public string GetConnection()
        {
            string environment = Mode == FactoryMode.TEST ? "Test" : "Prod";
            return Config[$"ConnectionStrings:{environment}"];
        }

    }
}
