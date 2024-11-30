using Microsoft.Extensions.DependencyInjection;
using StoreApp.DAL;
using StoreApp.DAL.File;
using StoreApp.DAL.Interfaces;
using StoreApp.BLL.Interfaces;
using StoreApp.BLL.Services;

var serviceProvider = new ServiceCollection()
    // Add JsonDataProvider with file path
    .AddSingleton(new JsonDataProvider("Data/TestData.json"))
    // BLL services
    .AddTransient<IStoreService, StoreService>()
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IStoreProductService, StoreProductService>()
    // DAL file repositories
    .AddTransient<IStoreRepository, FileStoreRepository>()
    .AddTransient<IProductRepository, FileProductRepository>()
    .AddTransient<IStoreProductRepository, FileStoreProductRepository>()
    .BuildServiceProvider();

var storeService = serviceProvider.GetRequiredService<IStoreService>();

// Test load stores
var stores = await storeService.GetAllStoresAsync();
foreach (var store in stores)
{
    Console.WriteLine($"Store: {store.Name}, Address: {store.Address}");
}