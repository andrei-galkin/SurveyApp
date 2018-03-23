using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess
{
    public static class ConfigProvider
    {
        public static IConfiguration Configuration { get; set; }

        public static string DbConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");
        }
    }
}
