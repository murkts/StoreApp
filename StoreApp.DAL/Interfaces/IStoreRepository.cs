namespace StoreApp.DAL.Interfaces;

using StoreApp.Data.Entities;

public interface IStoreRepository
{
    Task CreateAsync(Store store);
    Task<Store?> GetByIdAsync(Guid storeId);
    Task<Store?> GetByNameAsync(string storeName);
    Task<IEnumerable<Store>> GetAllAsync();
}