using System;
using System.Windows.Forms;
using StoreApp.DAL.File;
using StoreApp.DAL.Interfaces;

namespace StoreApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            IStoreRepository storeRepo;
            IProductRepository productRepo;
            IStoreProductRepository storeProductRepo;

            if (Config.RepositoryImplementation == "File")
            {
                storeRepo = new FileStoreRepository(Config.StoresFilePath);
                productRepo = new FileProductRepository(Config.ProductsFilePath);
                storeProductRepo = new FileStoreProductRepository(Config.StoreProductsFilePath);
            }
            else if (Config.RepositoryImplementation == "Database")
            {
                throw new NotImplementedException("Database repository not implemented yet.");
            }
            else
            {
                throw new InvalidOperationException("Invalid RepositoryImplementation in appsettings.json");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(storeRepo, productRepo, storeProductRepo));
        }
    }
}