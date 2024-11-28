using System;
using Microsoft.Extensions.Configuration;

namespace StoreApp
{
    public static class Config
    {
        private static readonly IConfigurationRoot Configuration;

        static Config()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string RepositoryImplementation => Configuration["RepositoryImplementation"];
        public static string StoresFilePath => Configuration["FilePaths:Stores"];
        public static string ProductsFilePath => Configuration["FilePaths:Products"];
        public static string StoreProductsFilePath => Configuration["FilePaths:StoreProducts"];
        public static string ConnectionString => Configuration["Database:ConnectionString"];
    }
}