namespace StoreApp.BLL.Interfaces;

using StoreApp.Data.Entities;

public interface IStoreService
{
    Task CreateStoreAsync(string name, string address);
    Task<Store?> GetStoreByNameAsync(string name);
    Task<IEnumerable<Store>> GetAllStoresAsync();
}