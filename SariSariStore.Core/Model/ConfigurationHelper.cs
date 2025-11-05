using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    public class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        static ConfigurationHelper()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public static string GetConnectionString(string name = "DefaultConnection")
        {
            return _configuration.GetConnectionString(name);
        }

        public static IConfiguration Configuration => _configuration;
    }
}
