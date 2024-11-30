namespace StoreApp.DAL.Interfaces;

using StoreApp.Data.Entities;

public interface IStoreProductRepository
{
    Task AddStockAsync(Guid storeId, string productName, int quantity, decimal price);
    Task<StoreProduct?> GetProductByStoreAsync(Guid storeId, string productName);
    Task<IEnumerable<StoreProduct>> GetProductsByStoreAsync(Guid storeId);
    Task UpdateStockAsync(Guid storeId, string productName, int quantity);
}