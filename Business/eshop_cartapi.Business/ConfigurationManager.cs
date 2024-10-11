using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace eshop_cartapi.Business
{
    public static class ConfigurationManager
    {
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
        public static IConfiguration AppSetting { get; }
    }
}
